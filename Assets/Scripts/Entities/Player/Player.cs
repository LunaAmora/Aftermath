using UnityEngine;

namespace Aftermath
{
    public class Player : Entity
    {
        [Space(10)]
        [SerializeField] private InputReader _input;
        [SerializeField] private PlayerModel _model;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private BossFlyingStage _stage;

        private float _lookAngle;
        private Vector3 _lookDir;
        private Vector3 _moveDir;
        private Vector2 _mousePos;
        private Plane _plane;
        private Plane _flyPlane;

        private bool _focusMode = false;

        void Start()
        {
            _input.OnMoveDirection += MoveDir;
            _input.OnMouseMove += LookDir;
            _input.OnMouseClick += Shoot;
            _input.OnCameraChange += CameraChange;
            _plane = new Plane(Vector3.up, transform.position);
            _flyPlane = new Plane(Vector3.back, _stage.transform.position);

            _input.Initialize();
        }

        void OnDestroy()
        {
            _input.OnMoveDirection -= MoveDir;
            _input.OnMouseMove -= LookDir;
            _input.OnMouseClick -= Shoot;
            _input.OnCameraChange -= CameraChange;
        }

        void Update()
        {
            LookAt();
            Animate();
        }

        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            if (_moveDir != Vector3.zero)
            {
                _rigidbody.MovePosition(transform.position + (_moveDir * _speed * Time.deltaTime));
            }
        }

        void LookAt()
        {
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(_mousePos);
            var plane = _focusMode ? _flyPlane : _plane;

            if (plane.Raycast(ray, out distance))
            {
                var worldPosition = ray.GetPoint(distance);
                _lookDir = (worldPosition - transform.position).normalized;
                _lookAngle = Vector3.SignedAngle(_lookDir, transform.forward, Vector3.down);
                _model.LookAt(_lookAngle);
            }
        }

        void Animate()
        {
            if (_moveDir == Vector3.zero)
            {
                _model.Animate(Vector2.zero);
            }
            else
            {
                var moveAngle = Vector3.SignedAngle(_moveDir, transform.forward, Vector3.down);
                var angle = (moveAngle - _lookAngle) * Mathf.Deg2Rad;
                var animDir = (new Vector2(Mathf.Sin(angle), Mathf.Cos(angle))).normalized;
                _model.Animate(animDir);
            }
        }

        void LookDir(Vector2 dir)
        {
            _mousePos = dir;
        }

        void MoveDir(Vector2 dir)
        {
            _moveDir = new Vector3(dir.x, 0, dir.y).normalized;
        }

        void Shoot()
        {
            var dir = _focusMode ? _lookDir : Vector3.forward;
            _model.Shoot(dir);
        }

        void CameraChange()
        {
            _focusMode = !_focusMode;
        }
    }
}

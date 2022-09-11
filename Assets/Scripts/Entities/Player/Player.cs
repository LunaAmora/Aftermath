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
        private Plane _plane;
        private Plane _flyPlane;

        private bool _focusMode = false;

        public void Initialize()
        {
            _input.OnMoveDirection += MoveDir;
            _input.OnMouseClick += Shoot;
            _input.OnMouseRelease += ShootRelease;
            _input.OnCameraChange += CameraChange;
            _plane = new Plane(Vector3.up, transform.position);
            _flyPlane = new Plane(Vector3.back, _stage.transform.position);
        }

        void OnDestroy()
        {
            _input.OnMoveDirection -= MoveDir;
            _input.OnMouseClick -= Shoot;
            _input.OnCameraChange -= CameraChange;
            _input.OnMouseRelease -= ShootRelease;
        }

        void Update()
        {
            if (GameManager.Instance.isPaused) return;
            LookAt();
            Animate();
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.isPaused) return;
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
            Ray ray = Camera.main.ScreenPointToRay(_input.MousePos);
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

        void CameraChange() => _focusMode = !_focusMode;
        void MoveDir(Vector2 dir) => _moveDir = new Vector3(dir.x, 0, dir.y).normalized;

        void Shoot()
        {
            if (GameManager.Instance.isPaused) return;
            _model.Shoot(() => _lookDir);
        }

        void ShootRelease()
        {
            if (GameManager.Instance.isPaused) return;
            _model.ShootRelease();
        }
    }
}

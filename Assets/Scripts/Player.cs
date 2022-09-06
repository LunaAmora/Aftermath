using Cinemachine.Utility;
using UnityEngine;

namespace Aftermath
{
    public class Player : Entity
    {
        [SerializeField] private float _speed;
        [Space(10)]

        [SerializeField] private InputReader _input;
        [SerializeField] private PlayerWeapon _weapon;
        [SerializeField] private PlayerModel _model;

        private float _lookAngle;
        private Vector3 _moveDir;
        private Vector2 _mousePos;
        private Plane _plane;

        void Start()
        {
            _input.OnMoveDirection += MoveDir;
            _input.OnMouseMove += LookDir;
            _input.OnMouseClick += Shoot;
            _plane = new Plane(Vector3.up, transform.position);

            _input.Initialize();
        }

        void OnDestroy()
        {
            _input.OnMoveDirection -= MoveDir;
            _input.OnMouseMove -= LookDir;
            _input.OnMouseClick -= Shoot;
        }

        void Update()
        {
            Move();
            LookAt();
            Animate();
        }

        void Move()
        {
            if (_moveDir != Vector3.zero)
            {
                transform.Translate(_moveDir * _speed * Time.deltaTime, Space.World);
            }
        }

        void LookAt()
        {
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(_mousePos);
            if (_plane.Raycast(ray, out distance))
            {
                var worldPosition = ray.GetPoint(distance);
                var lookDir = (worldPosition - transform.position).normalized;
                _lookAngle = Vector3.SignedAngle(lookDir, transform.forward, Vector3.down);
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
                var animDir = (new Vector2(Mathf.Sin(angle), Mathf.Cos(angle))).SquareNormalize();
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
            _weapon.Shoot();
        }
    }
}

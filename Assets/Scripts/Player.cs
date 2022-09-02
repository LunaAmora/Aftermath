using UnityEngine;

namespace Aftermath
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputReader _input;
        [SerializeField] private PlayerWeapon _weapon;
        [SerializeField] private float _speed;

        private Transform _transform;
        private Vector3 _moveDir;
        private Vector2 _mousePos;

        void Start()
        {
            _input.OnMoveDirection += MoveDir;
            _input.OnMouseMove += LookDir;
            _input.OnMouseClick += Shoot;

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
        }

        private void Move()
        {
            if (_moveDir != Vector3.zero)
            {
                transform.Translate(_moveDir * _speed * Time.deltaTime, Space.World);
            }
        }

        private void Shoot()
        {
            _weapon.Shoot();
        }

        private void LookAt()
        {
            var pos = (Vector2) Camera.main.WorldToScreenPoint(transform.position);
            var direc = (_mousePos - pos);
            var angle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg;

            transform.LeanRotateY(-angle, 0.1f);
        }

        private void LookDir(Vector2 dir)
        {
            _mousePos = dir;
        }

        private void MoveDir(Vector2 dir)
        {
            _moveDir = new Vector3(-dir.y, 0, dir.x).normalized;
        }
    }
}

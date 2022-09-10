using UnityEngine;

namespace Aftermath
{
    public class PlayerModel : MonoBehaviour
    {
        [SerializeField] private PlayerWeapon _weapon;
        [SerializeField] Animator _animator;
        [SerializeField] Transform _spine;

        private bool _shooting;
        private float _lastDir;

        public void LookAt(float angle)
        {
            transform.LeanRotateY(angle, 0.1f);
        }

        public void Animate(Vector2 dir)
        {
            _lastDir = dir.x;
            _animator.SetFloat("XDir", dir.x);
            _animator.SetFloat("ZDir", dir.y);
        }

        public void Shoot()
        {
            _shooting = true;
            _animator.SetTrigger("Shoot");
        }

        public void AnimEventShoot()
        {
            _weapon.Shoot(transform.forward);
            _shooting = false;
        }

        void LateUpdate()
        {
            if (_shooting && _lastDir != 0)
            {
                var angles = _spine.localEulerAngles;
                angles.y = -90 * _lastDir;
                _spine.localEulerAngles = angles;
            }
        }
    }
}

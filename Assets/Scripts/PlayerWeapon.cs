using UnityEngine;

namespace Aftermath
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] Transform _spawnPoint;
        [SerializeField] Projetil _projPrefab;
        [SerializeField] float _projForce;
        [SerializeField] Animator _animator;

        public void Shoot(Vector3 dir)
        {
            var proj = Object.Instantiate<Projetil>(_projPrefab, _spawnPoint.position, _spawnPoint.rotation);
            proj.Impulse(_projForce, dir);
            _animator.SetTrigger("Shoot");
        }
    }
}

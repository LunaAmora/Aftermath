using UnityEngine;

namespace Aftermath
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] Transform _spawnPoint;
        [SerializeField] Projetil _projPrefab;
        [SerializeField] float _projForce;

        public void Shoot()
        {
            var proj = Object.Instantiate<Projetil>(_projPrefab, _spawnPoint.position, _spawnPoint.rotation);
            proj.Impulse(_projForce);
        }
    }
}

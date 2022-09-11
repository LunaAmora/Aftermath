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
            proj.Impulse(_projForce, dir, SoundPlayer.AudioEnum.DamagedBoss);
            SoundPlayer.Instance.PlayAudio(RandSound());
            _animator.SetTrigger("Shoot");
        }

        SoundPlayer.AudioEnum RandSound()
        {
            return Random.Range(0, 1) switch
            {
                0 => SoundPlayer.AudioEnum.TiroPlayer,
                _ => SoundPlayer.AudioEnum.TiroPlayer2,
            };
        }
    }
}

using System;
using UnityEngine;

namespace Aftermath
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projetil : MonoBehaviour
    {
        [SerializeField] private float _duration = 2f;
        [SerializeField] private float _damage = 10f;
        private ProjOwner _owner;

        public void Impulse(float force, Vector3 dir, ProjOwner owner = ProjOwner.Player)
        {
            _owner = owner;
            GetComponent<Rigidbody>().AddForce(dir * force);
            gameObject.LeanDelayedCall(_duration, () => Destroy(gameObject));
        }

        void OnCollisionEnter(Collision hit)
        {
            Entity entity = (_owner, hit.transform.gameObject.tag) switch
            {
                (ProjOwner.Boss, "Player") => hit.transform.gameObject.GetComponent<Player>(),
                (ProjOwner.Player, "Boss") => hit.transform.gameObject.GetComponent<Boss>(),
                (_, _) => null
            };

            if (entity != null)
            {
                entity.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }

    public enum ProjOwner
    {
        Boss,
        Player,
    }
}

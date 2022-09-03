using UnityEngine;

namespace Aftermath
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projetil : MonoBehaviour
    {
        [SerializeField] private float _duration = 2f;

        public void Impulse(float force)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
            gameObject.LeanDelayedCall(_duration, () => Destroy(gameObject));
        }
    }
}

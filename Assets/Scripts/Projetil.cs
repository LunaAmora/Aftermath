using UnityEngine;

namespace Aftermath
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projetil : MonoBehaviour
    {
        public void Impulse(float force)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }
    }
}

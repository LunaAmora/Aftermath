using UnityEngine;

namespace Aftermath
{
    public class PlayerModel : MonoBehaviour
    {
        public void LookAt(float angle)
        {
            transform.LeanRotateY(angle, 0.1f);
        }
    }
}

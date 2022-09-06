using UnityEngine;

namespace Aftermath
{
    public class PlayerModel : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        public void LookAt(float angle)
        {
            transform.LeanRotateY(angle, 0.1f);
        }

        public void Animate(Vector2 dir)
        {
            _animator.SetFloat("XDir", dir.x);
            _animator.SetFloat("ZDir", dir.y);
        }
    }
}

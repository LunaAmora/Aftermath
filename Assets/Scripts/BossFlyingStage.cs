using UnityEngine;

namespace Aftermath
{
    public class BossFlyingStage : MonoBehaviour
    {
        [SerializeField] private Range _verticalRange;
        [SerializeField] private Range _horizontalRange;

        public Vector3 GetPosition(Vector2 coordPercent)
        {
            var result = transform.position;
            result.y += _verticalRange * coordPercent.y;
            result.x += _horizontalRange * coordPercent.x;
            return result;
        }
    }
}

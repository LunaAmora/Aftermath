using System;
using UnityEngine;

namespace Aftermath
{
    [Serializable]
    public struct Range
    {
        public float Min;
        public float Max;

        public static float operator *(Range range, float percent)
            => range.Min + (range.Max - range.Min) * Mathf.Clamp01(percent);
    }
}

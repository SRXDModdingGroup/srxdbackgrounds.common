using UnityEngine;

namespace SRXDBackgrounds.Common {
    public static class Util {
        public static float Interpolate(float a, float b, float t, InterpolationType interpolationType)
            => Mathf.Lerp(a, b, GetInterpolationFactor(t, interpolationType));

        internal static float GetInterpolationFactor(float t, InterpolationType interpolationType) => interpolationType switch {
            InterpolationType.Linear => t,
            InterpolationType.Smooth => t * t * (3f - 2f * t),
            InterpolationType.EaseOut => 1f - (1f - t) * (1f - t),
            InterpolationType.EaseIn => t * t,
            _ => t
        };
    }
}
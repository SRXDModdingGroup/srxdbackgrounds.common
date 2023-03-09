using UnityEngine;

namespace SRXDBackgrounds.Common {
    public class EnvelopeBasic {
        public float Speed { get; set; }

        public float Duration {
            get => 1f / Speed;
            set => Speed = 1f / value;
        }
        
        public bool Invert { get; set; }

        public InterpolationType InterpolationType { get; set; } = InterpolationType.Linear;
        
        private float phase = 1f;
        
        public void Trigger() => phase = 0f;

        public void Reset() => phase = 1f;

        public float Update(float deltaTime) {
            phase = Mathf.Min(phase + Speed * deltaTime, 1f);
            
            if (Invert)
                return 1f - Util.GetInterpolationFactor(phase, InterpolationType);

            return Util.GetInterpolationFactor(phase, InterpolationType);
        }
    }
}
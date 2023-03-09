namespace SRXDBackgrounds.Common {
    public class EnvelopeADSR {
        public float Attack { get; set; }
        
        public float Decay { get; set; }
        
        public float Sustain { get; set; }
        
        public float Release { get; set; }
        
        public bool Invert { get; set; }
        
        public InterpolationType AttackInterpolationType { get; set; } = InterpolationType.Linear;
        
        public InterpolationType DecayInterpolationType { get; set; } = InterpolationType.Linear;
        
        public InterpolationType ReleaseInterpolationType { get; set; } = InterpolationType.Linear;

        private float phase = 2f;
        private float releasePhase = 1f;
        private bool sustained;

        public void Trigger() {
            phase = 0f;
            releasePhase = 0f;
            sustained = true;
        }

        public void EndSustain() {
            releasePhase = 0f;
            sustained = false;
        }

        public void Reset() {
            phase = 2f;
            releasePhase = 1f;
            sustained = false;
        }

        public float Update(float deltaTime) {
            if (Invert)
                return 1f - UpdateAttackDecay(deltaTime) * UpdateRelease(deltaTime);
            
            return UpdateAttackDecay(deltaTime) * UpdateRelease(deltaTime);
        }

        private float UpdateAttackDecay(float deltaTime) {
            if (phase < 1f) {
                if (Attack <= 0f)
                    phase = 1f;
                else {
                    float remaining = Attack * (1f - phase);

                    if (deltaTime <= remaining) {
                        phase += deltaTime / Attack;

                        return Util.GetInterpolationFactor(phase, AttackInterpolationType);
                    }

                    phase = 1f;
                    deltaTime -= remaining;
                }
            }

            if (phase >= 2f || Decay <= 0f) {
                phase = 2f;

                return Sustain;
            }

            phase += deltaTime / Decay;

            if (phase < 2f)
                return Util.Interpolate(1f, Sustain, phase - 1f, DecayInterpolationType);
            
            phase = 2f;

            return Sustain;
        }

        private float UpdateRelease(float deltaTime) {
            if (sustained) {
                releasePhase = 0f;

                return 1f;
            }
            
            if (releasePhase >= 1f || Release <= 0f) {
                releasePhase = 1f;

                return 0f;
            }

            releasePhase += deltaTime / Release;

            if (releasePhase < 1f)
                return 1f - Util.GetInterpolationFactor(releasePhase, ReleaseInterpolationType);
            
            releasePhase = 1f;

            return 0f;
        }
    }
}
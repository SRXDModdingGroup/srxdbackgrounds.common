using UnityEngine;

namespace SRXDBackgrounds.Common {
    public class Oscillator {
        public float Speed { get; set; }

        public float Duration {
            get => 1f / Speed;
            set => Speed = 1f / value;
        }

        public OscillatorType Type { get; set; } = OscillatorType.Sine;
        
        private float phase;

        public void SetPhase(float phase) => this.phase = phase;

        public float Update(float deltaTime) {
            phase = Mathf.Repeat(phase + Speed * deltaTime, 1f);

            return Type switch {
                OscillatorType.Sine => 2f * Mathf.Sin(2f * Mathf.PI * phase) - 1f,
                OscillatorType.Sawtooth => phase,
                OscillatorType.Square => phase < 0.5f ? 1f : 0f,
                OscillatorType.Triangle => 1f - 2f * Mathf.Abs(Mathf.Floor(phase + 0.25f) - phase + 0.25f),
                _ => phase
            };
        }
    }
}
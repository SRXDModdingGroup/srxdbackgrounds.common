using UnityEngine;

namespace SRXDBackgrounds.Common {
    public class Filter {
        public float RateUpward { get; set; }
        
        public float RateDownward { get; set; }

        public FilterType Type { get; set; } = FilterType.Linear;
        
        private float value;

        public void SetValue(float value) => this.value = value;
        
        public float Update(float target, float deltaTime) {
            float rate = target > value ? RateUpward : RateDownward;

            value = Type switch {
                FilterType.Linear => Mathf.MoveTowards(value, target, rate),
                _ => target
            };

            return value;
        }
    }
}
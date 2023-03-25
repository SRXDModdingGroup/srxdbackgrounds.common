using BepInEx;
using UnityEngine;

namespace SRXDBackgrounds.Common {
    [BepInDependency("srxd.customvisuals", "1.2.5")]
    [BepInPlugin("srxd.backgrounds.common", "srxdbackgrounds.common", "1.0.2")]
    public class Plugin : MonoBehaviour {
        private void Awake() => Destroy(gameObject);
    }
}

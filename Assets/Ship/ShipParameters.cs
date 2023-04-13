using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    [CreateAssetMenu(fileName = "ShipParameters", menuName = "Scriptable Object/ShipParameters", order = 1)]
    public class ShipParameters : ScriptableObject
    {
        public bool useMouse;
        public bool useAI;

        public float hp = 100f;
        public float forceMultiplier;
        public float rotationMultiplier;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assembly_CSharp
{
    internal interface IShipInput
    {
        public Vector3 MouseInput
        {
            get; set;
        }

        public bool MouseDown
        {
            get; set;
        }

        public float InputAngle
        {
            get; set;
        }

    }
}

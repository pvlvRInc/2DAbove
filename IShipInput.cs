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
        public float ToMouseMagnitude
        {
            get;
        }

        public bool MouseDown
        {
            get;
        }

        public float InputAngle
        {
            get;
        }


    }
}

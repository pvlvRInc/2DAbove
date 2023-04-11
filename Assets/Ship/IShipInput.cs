using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public interface IShipInput
    {
        public float ToMouseMagnitude
        {
            get;
        }

        public bool Moving
        {
            get;
        }

        public float InputAngle
        {
            get;
        }

        public void ReadInput();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public interface IKnockbackReceiver
    {
        public void ReceiveKnockback(CollideParameters collideParameters);
    }
}

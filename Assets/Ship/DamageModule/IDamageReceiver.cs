using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pradev
{
    public interface IDamageReceiver
    {
        public void ReceiveDamage(CollideParameters collideParameters);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public class SimpleKnockbackReceiver : IKnockbackReceiver
    {
        private ShipParameters _shipParameters;
        private IPhysicsModule _physicsModule;
        private Rigidbody2D _rigidbody;

        public SimpleKnockbackReceiver(ShipParameters shipParameters, IPhysicsModule physicsModule, Rigidbody2D rigidbody)
        {
            _shipParameters = shipParameters; //maybe get maxhp from damage receiver?
            _physicsModule = physicsModule;
            _rigidbody = rigidbody;

            _physicsModule.OnDamageTaken += ReceiveKnockback;
        }

        public void ReceiveKnockback(CollideParameters collideParameters)
        {
            //_rigidbody.AddForce(collideParameters.Knockback * _shipParameters.forceMultiplier * collideParameters.Damage/_shipParameters.hp);
            _rigidbody.AddForce(collideParameters.Knockback * _shipParameters.forceMultiplier);
        }
    }
}

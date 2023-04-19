using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public class SimpleDamageReceiver : IDamageReceiver
    {
        private IPhysicsModule _physicsModule;
        private GameObject _gameObject;
        private float _maxHp; // do i need this?
        private float _currentHp;

        public SimpleDamageReceiver(ShipParameters shipParameters, IPhysicsModule physicsModule, GameObject gameObject)
        {
            _physicsModule = physicsModule;
            _gameObject = gameObject;
            _maxHp = shipParameters.hp;
            _currentHp = shipParameters.hp;

            _physicsModule.OnDamageTaken += ReceiveDamage;
        }


        public void ReceiveDamage(CollideParameters collideParameters)
        {
            _currentHp -= collideParameters.Damage;
            if (_currentHp <= 0)
            {
                GameObject.Destroy(_gameObject);
            }
        }
    }
}

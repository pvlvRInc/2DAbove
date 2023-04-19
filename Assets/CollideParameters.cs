using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public class CollideParameters
    {
        private float _damage;
        private Vector2 _knockback;

        public CollideParameters(float damage, Vector2 knockback) { 
            _damage = damage;
            _knockback = knockback;
        }

        public float Damage => _damage;
        public Vector2 Knockback => _knockback;
    }
}

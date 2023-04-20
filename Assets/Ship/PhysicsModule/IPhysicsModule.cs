using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace pradev
{
    public interface IPhysicsModule
    {
        public UnityAction<CollideParameters> OnDamageTaken { get; set; }
        public Vector2 Velocity { get; }

        public void HandleCollide(Collider2D collision);
    }
}

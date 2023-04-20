using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace pradev
{
    public class SimplePhysicsModule : IPhysicsModule
    {
        private Rigidbody2D _rigidbody;
        private UnityAction<CollideParameters> _OnDamageTaken;

        public SimplePhysicsModule(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;

            Initialize();
        }

        public Vector2 Velocity => _rigidbody.velocity;

        public UnityAction<CollideParameters> OnDamageTaken
        {
            get => _OnDamageTaken;
            set
            {
                _OnDamageTaken = value;
            }
        }

        private void Initialize()
        {
            _rigidbody.gameObject.layer = LayerMask.NameToLayer("Enemy"); //todo determine for player too
            _rigidbody.gameObject.AddComponent<BoxCollider2D>();

            _rigidbody.mass = 0.016f;
            _rigidbody.drag = 3.2f;
            _rigidbody.gravityScale = 0;
        }


        public void HandleCollide(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Bullets"))
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>(); // Todo make general projectile-aoe
                if (bullet.IsOwnedByPlayer) //todo determine for player too
                {
                    _OnDamageTaken?.Invoke(new CollideParameters(bullet.Damage, bullet.Velocity));
                    //GetDamage(bullet.Damage);
                    //GetKnockback(bullet);
                    bullet.HitDestroy(); // todo remove zalupa
                }
            }
        }
    }
}

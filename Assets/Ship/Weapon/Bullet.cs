using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Transform _startPoint;
        private WeaponParameters _weaponParameters;
        private Rigidbody2D _rigidbody;
        private bool _isOwnedByPlayer;

        //Cashing
        private float _damage;
        private Transform _bullet;
        private float _timeCreated;
        private float _timeDestroy;
        float _additionalVelocity;

        public void Initialize(WeaponParameters parameters, Transform ship, Rigidbody2D rigidbody, bool isOwnedByPlayer)
        {
            _startPoint = ship;
            _weaponParameters = parameters;
            _rigidbody = rigidbody;
            _isOwnedByPlayer = isOwnedByPlayer;

            Create();
        }

        private void Create()
        {
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;

            _bullet = transform;
            _damage = UnityEngine.Random.Range(_weaponParameters.minDamage, _weaponParameters.maxDamage);
            _timeCreated = Time.time;
            _timeDestroy = _timeCreated + _weaponParameters.lifetime;

            _bullet.position = _startPoint.position;
            _bullet.rotation = _startPoint.rotation;
            float halfAngle = _weaponParameters.angle / 2;
            _bullet.Rotate(transform.forward * UnityEngine.Random.Range(-halfAngle, halfAngle));


            _additionalVelocity = Mathf.Min((_rigidbody.velocity / 20 * transform.up).magnitude, .3f);
        }

        public void Update()
        {
            Move();
            //DealDamage();
            CheckDestroy();

        }

        private void Move()
        {
            _bullet.localPosition += _bullet.up * (_weaponParameters.projectileSpeed + _additionalVelocity * Time.deltaTime);
            //Debug.Log(additionalVelocity);
        }

        private void CheckDestroy()
        {
            if (Time.time > _timeDestroy)
            {
                GameObject.DestroyImmediate(gameObject);
            }
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.name);
            if (_isOwnedByPlayer && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Enemy target = other.GetComponent<Enemy>();
                target.GetDamage(_damage);
            }
        }
    }
}

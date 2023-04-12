using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public class Bullet : MonoBehaviour
    {
        private Transform _startPoint;
        private WeaponParameters _weaponParameters;
        private Rigidbody2D _rigidbody;

        //Cashing
        private float _damage;
        private Transform _bullet;
        private Collider _collider;
        private float _timeCreated;
        private float _timeDestroy;
        float _additionalVelocity;

        public void Initialize(WeaponParameters parameters, Transform ship, Rigidbody2D rigidbody)
        {
            _startPoint = ship;
            _weaponParameters = parameters;
            _rigidbody = rigidbody;

            Create();
        }

        private void Create()
        {
            _bullet = transform;
            _damage = UnityEngine.Random.Range(_weaponParameters.minDamage, _weaponParameters.maxDamage);
            _timeCreated = Time.time;
            _timeDestroy = _timeCreated + _weaponParameters.lifetime;

            _bullet.position = _startPoint.position;
            _bullet.rotation = _startPoint.rotation;
            float halfAngle = _weaponParameters.angle / 2;
            _bullet.Rotate( transform.forward * UnityEngine.Random.Range(-halfAngle, halfAngle));


            _additionalVelocity = Mathf.Min((_rigidbody.velocity / 20 * transform.up).magnitude,.3f);
        }

        public void Update()
        {
            Move();
            //DealDamage();
            CheckDestroy();

        }

        private void DealDamage()
        {
            throw new NotImplementedException(null);
        }

        private void Move()
        {
            _bullet.localPosition += _bullet.up * (_weaponParameters.projectileSpeed + _additionalVelocity);
            //Debug.Log(additionalVelocity);
        }

        private void CheckDestroy()
        {
            if (Time.time > _timeDestroy)
            {
                GameObject.DestroyImmediate(gameObject);
            }
        }
    }
}

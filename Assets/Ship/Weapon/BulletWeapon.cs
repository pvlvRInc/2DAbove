using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    internal class BulletWeapon : IWeapon
    {

        private WeaponParameters _weaponParameters;
        private IShipInput _input;
        private Transform _ship;
        private Rigidbody2D _rigidbody;

        //Cashing
        private float _timeShoot;

        public BulletWeapon(WeaponParameters parameters, IShipInput input, Transform startPoint, Rigidbody2D rigidbody)
        {
            _weaponParameters = parameters;
            _input = input;
            _ship = startPoint;
            _rigidbody = rigidbody;

            _timeShoot = Time.time + 1 / _weaponParameters.fireRate;
        }

        public void Shoot()
        {
            if (_input.Fire && _timeShoot < Time.time)
            {
                _timeShoot = Time.time + 1 / _weaponParameters.fireRate;

                for (int i = 0; i < _weaponParameters.projectileCount; i++)
                {
                    GameObject bullet = GameObject.Instantiate(_weaponParameters.bulletShape);
                    bullet.AddComponent<Bullet>().Initialize(_weaponParameters, _ship, _rigidbody);
                }
            }
        }
    }
}

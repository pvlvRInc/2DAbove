using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    [CreateAssetMenu(fileName = "WeaponParameters", menuName = "Scriptable Object/WeaponParameters", order = 2)]
    public class WeaponParameters : ScriptableObject
    {
        public float minDamage;
        public float maxDamage;
        public float fireRate;
        public int projectileCount;
        public float angle;

        public bool isRotating;
        public float rotateSpeed;
        public float projectileSpeed;
        public float lifetime;

        public GameObject bulletShape;
    }
}
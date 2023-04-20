using pradev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pradev
{
    [CreateAssetMenu(fileName = "EnemyParameters", menuName = "Scriptable Object/EnemyParameters", order = 3)]
    public class EnemyParameters : ShipParameters
    {
        public float cost;
        public float aggressivness;

        // package from https://github.com/mackysoft/Unity-SerializeReferenceExtensions
        [SerializeReference, SubclassSelector]
        public IShipInput input;

        public WeaponParameters WeaponParameters;

        public GameObject shape;
    }
}
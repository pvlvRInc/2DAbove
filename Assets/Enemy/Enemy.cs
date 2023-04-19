using pradev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    private EnemyParameters _enemyParameters;
    private Transform _target;
    private IShipInput _input;
    private ShipMotor _enemyMotor;
    private IPhysicsModule _physicsModule;
    private IDamageReceiver _damageReceiver;
    private IKnockbackReceiver _knockbackReceiver;

    //Cashing
    private Rigidbody2D _rigidbody;

    public void Initialize(EnemyParameters parameters, Transform target)
    {
        _enemyParameters = parameters;
        _target = target;

        _rigidbody = gameObject.AddComponent<Rigidbody2D>();

        var args = new object[] { transform, _target };
        _input = (IShipInput)Activator.CreateInstance(_enemyParameters.input.GetType(), args);
        _enemyMotor = new ShipMotor(_enemyParameters, _input, transform, _rigidbody);

        // todo Create from interface
        _physicsModule = new SimplePhysicsModule(_rigidbody); 
        _damageReceiver = new SimpleDamageReceiver(_enemyParameters, _physicsModule, gameObject);
        _knockbackReceiver = new SimpleKnockbackReceiver(_enemyParameters, _physicsModule, _rigidbody);

    }

    public void Update()
    {
        _input.ReadInput();
        _enemyMotor.Move();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _physicsModule.HandleCollide(collision);
    }
}


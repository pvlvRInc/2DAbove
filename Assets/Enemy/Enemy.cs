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
    private ShipParameters _enemyShipParameters;

    //Cashing
    private Rigidbody2D _rigidbody;

    public void Initialize(EnemyParameters parameters, Transform target)
    {
        _enemyParameters = parameters;
        _target = target;


        gameObject.AddComponent<BoxCollider2D>();
        _rigidbody = gameObject.AddComponent<Rigidbody2D>();
        _rigidbody.mass = 0.016f;
        _rigidbody.drag = 3.2f;
        _rigidbody.gravityScale = 0;


        var args = new object[] { transform, _target };
        _input = (IShipInput)Activator.CreateInstance(_enemyParameters.input.GetType(), args);
        _enemyMotor = new ShipMotor(_enemyParameters, _input, transform, _rigidbody);
    }

    public void Update()
    {
        _input.ReadInput();
        _enemyMotor.Move();
    }
}


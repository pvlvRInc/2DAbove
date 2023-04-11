using pradev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ShipParameters _shipParameters;
    [SerializeField] private WeaponParameters _weaponParameters;

    private Rigidbody2D _rigidbody;
    private IShipInput _input;
    private ShipMotor _motor;
    private IWeapon _weapon;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInput(Camera.main, transform);
        _motor = new ShipMotor(_shipParameters, _input, transform, _rigidbody);
        _weapon = new BulletWeapon(_weaponParameters, _input, transform);
    }

    public void Update()
    {
        _input.ReadInput();
        _motor.Move();
        _weapon.Shoot();
    }


}

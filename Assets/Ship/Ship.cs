using pradev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ShipParameters _parameters;

    private Rigidbody2D _rigidbody;
    private IShipInput _input;
    private ShipMotor _motor;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInput(Camera.main, transform);
        _motor = new ShipMotor(_parameters, _input, transform, _rigidbody);
    }

    public void Update()
    {
        _input.ReadInput();
        _motor.Move();

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 dirToMouse = (mousePos - transform.position);
        //float dirAngle = Mathf.Atan2(dirToMouse.normalized.x, dirToMouse.normalized.y) * Mathf.Rad2Deg;

        //float rotationSpeed = 0.01f * _rotationSpeed * dirToMouse.magnitude / 3;

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.back * dirAngle), rotationSpeed);


        //if (Input.GetMouseButton(0))
        //{
        //    _rigidbody.AddForce(transform.up * Time.deltaTime * _forceMulti * Mathf.Min(Mathf.Max(dirToMouse.magnitude - 10.05f, 0), 1));
        //}

        Debug.Log($"magnitude {_input.ToMouseMagnitude}");

    }
}

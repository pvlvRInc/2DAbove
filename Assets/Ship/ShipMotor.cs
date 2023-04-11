using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public class ShipMotor
    {
        ShipParameters _shipParameters;
        IShipInput _shipInput;
        Transform _shipTransform;
        Rigidbody2D _shipRigidbody;

        public ShipMotor(ShipParameters shipParams, IShipInput input, Transform transform, Rigidbody2D rigidbody)
        {
            _shipParameters = shipParams;
            _shipInput = input;
            _shipTransform = transform;
            _shipRigidbody = rigidbody;
        }

        public void Move()
        {
            float rotationSpeed = 0.01f * _shipParameters.rotationMultiplier;
            if (_shipParameters.useMouse)
                rotationSpeed *= _shipInput.ToMouseMagnitude / .3f;

            _shipTransform.rotation = Quaternion.Lerp(_shipTransform.rotation, Quaternion.Euler(Vector3.back * _shipInput.InputAngle), rotationSpeed);

            if (_shipInput.Moving)
            {
                Vector3 force = _shipTransform.up * Time.deltaTime * _shipParameters.forceMultiplier;
                if (_shipParameters.useMouse)
                    force *= Mathf.Min(Mathf.Max(_shipInput.ToMouseMagnitude - 0.8f, 0), 1);
                _shipRigidbody.AddForce(force);
            }
        }
    }
}

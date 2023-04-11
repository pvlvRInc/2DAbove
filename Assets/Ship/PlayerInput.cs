using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace pradev
{
    public class PlayerInput : IShipInput
    {
        Camera _camera;
        Transform _transform;


        //Cashing
        Vector3 _dirToMouse;
        float _ToMouseMagnitude;
        float _inputAngle;
        bool _mouseDown;

        public PlayerInput(Camera camera, Transform transform)
        {
            _camera = camera;
            _transform = transform;

            _dirToMouse = Vector3.zero;
        }

        public float ToMouseMagnitude => _ToMouseMagnitude;

        public float InputAngle => _inputAngle;

        public bool Moving => _mouseDown;

        public void ReadInput()
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = _transform.position.z;

            _dirToMouse = (mousePos - _transform.position);
            _ToMouseMagnitude = _dirToMouse.magnitude;
            _inputAngle = Mathf.Atan2(_dirToMouse.normalized.x, _dirToMouse.normalized.y) * Mathf.Rad2Deg;

            _mouseDown = Input.GetMouseButton(0);
        }

    }
}

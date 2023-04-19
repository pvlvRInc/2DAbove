using pradev;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SimpleEnemyBehaviour : IShipInput
{
    private Transform _target;
    private Transform _transform;

    //Cashing
    private Vector3 _dirToTarget;
    private float _ToTargetMagnitude;
    private float _inputAngle;
    private bool _isMoving;
    private bool _isShooting;

    public SimpleEnemyBehaviour() { }
    public SimpleEnemyBehaviour(Transform transform, Transform target)
    {
        _transform = transform;
        _target = target;
    }
    public float ToMouseMagnitude => _ToTargetMagnitude;

    public bool Moving => _isMoving;

    public bool Fire => _isShooting;

    public float InputAngle => _inputAngle;

    public void ReadInput()
    {
        Vector3 targetPos = _target.position;

        _dirToTarget = (targetPos - _transform.position);
        _ToTargetMagnitude = _dirToTarget.magnitude;
        _inputAngle = Mathf.Atan2(_dirToTarget.normalized.x, _dirToTarget.normalized.y) * Mathf.Rad2Deg;

        _isMoving = true;
        _isShooting = false;
    }
}

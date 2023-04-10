using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float forceMulti;
    [SerializeField] private float rotationSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dirToMouse = (mousePos - transform.position);
        float dirAngle = Mathf.Atan2(dirToMouse.normalized.x, dirToMouse.normalized.y) * Mathf.Rad2Deg;

        mousePos.z = transform.position.z;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.back * dirAngle), 0.01f * rotationSpeed * dirToMouse.magnitude / 3);


        if (Input.GetMouseButton(0))
        {
            _rigidbody.AddForce(transform.up * Time.deltaTime * forceMulti * Mathf.Min(Mathf.Max(dirToMouse.magnitude - 10.05f, 0), 1));
        }

        Debug.Log($"magnitude {dirToMouse.magnitude}");

    }
}

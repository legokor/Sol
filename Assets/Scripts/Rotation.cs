using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotation : MonoBehaviour
{
    public float rotationSpeed = -2000;

    void FixedUpdate()
    {
        Rigidbody body = gameObject.GetComponent<Rigidbody>();

        body.angularDrag = 0;
        body.AddTorque(0, rotationSpeed, 0);

        Destroy(this);
    }
}

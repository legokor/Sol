using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    public float posRecovery = 200;
    public float rotRecovery = 10;


    Vector3 startpos;
    Quaternion startrot;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        startpos = transform.position;
        startrot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 diff = startpos - transform.position;
        

        if (body != null)
        {
            diff.Set(diff.x * diff.x * diff.x, diff.y * diff.y * diff.y, diff.z * diff.z * diff.z);
            body.AddForce(diff * posRecovery - Physics.gravity);
        }

        /*
        float timeDiffRot = Time.fixedDeltaTime * rotRecovery;
        float timeDiffPos = Time.fixedDeltaTime * posRecovery;
        transform.rotation = Quaternion.Lerp(transform.rotation, startrot, timeDiffRot);
        transform.position = Vector3.Lerp(transform.position, startpos, timeDiffPos);
        if (body != null)
        {
            

            body.angularVelocity = Vector3.Lerp(body.angularVelocity, Vector3.zero, timeDiffRot);
            body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, timeDiffPos);
        } */
    }

    public void Return()
    {
        transform.position = startpos;
        transform.rotation = startrot;
        if (body != null)
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
    }
}

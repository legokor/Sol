using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectPuller : MonoBehaviour
{
    static readonly List<Rigidbody> objects = new List<Rigidbody>();
    Rigidbody body;
    public static void gravitationalPull(Rigidbody body, Rigidbody target)
    {
        Vector3 direction = target.transform.position - body.transform.position;
        float r = direction.magnitude;
        body.AddForce(direction.normalized * ObjectPullerManager.G * body.mass * target.mass / (r * r));
    }
    
    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        objects.Add(body);
    }

    void FixedUpdate()
    {
        /*Parallel.ForEach(objects, target =>
        {
            if (target != body)
            {
                gravitationalPull(body, target);
            }
        });*/
        foreach(Rigidbody target in objects)
        {
            if (target != body)
            {
                gravitationalPull(body, target);
            }
        }
        body.AddForce(-Physics.gravity*body.mass);
    }

    void OnDisable()
    {
        objects.Remove(body);
    }

    

}

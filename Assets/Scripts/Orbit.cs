using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPuller))]
public class Orbit : MonoBehaviour
{
    public Rigidbody centerOfOrbit;
    public float L_O_N_G_N_E_S_S = 1;

    void AddOrbit(Rigidbody centerOfOrbit, Transform orbitOffset, Rigidbody orbiter)
    {
        Vector3 toCenter = centerOfOrbit.transform.position - orbitOffset.position;
        float R = toCenter.magnitude;
        float Vk1 = Mathf.Sqrt(ObjectPullerManager.G * centerOfOrbit.mass / R);
        Vector3 startingDirection = Quaternion.Euler(0, 90, 0) * toCenter;
        orbiter.velocity += startingDirection.normalized * Vk1 * L_O_N_G_N_E_S_S;
    }

    void FixedUpdate()
    {
        Rigidbody body = gameObject.GetComponent<Rigidbody>();

        /*body.velocity = Vector3.zero;
        ObjectPuller.gravitationalPull(body, centerOfOrbit);
        Vector3 startingDirection = Quaternion.Euler(0, 90, 0) * body.velocity;
        Debug.Log("Starting direction: " + startingDirection);
        body.velocity = startingDirection*100;
        Nem mükszik de nem is olyan szar azé */

        Orbit target = this;
        while(target)
        {
            AddOrbit(target.centerOfOrbit, target.transform, body);
            target = target.centerOfOrbit.GetComponent<Orbit>();
        }

        enabled = false;
    }

}
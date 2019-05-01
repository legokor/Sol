using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
    public GameObject shotObjectType;
    public float shotVelocity;

    
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray startRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 startPosition = startRay.origin;
            GameObject shotObject = Instantiate(shotObjectType);
            shotObject.transform.position = startPosition;
            //shotObject.GetComponent<Rigidbody>().velocity = (startPosition - Camera.main.transform.position).normalized * shotVelocity;
            //shotObject.GetComponent<Rigidbody>().AddForce((startPosition - Camera.main.transform.position).normalized * shotVelocity);
            PlanetFollower follower = Camera.main.GetComponent<PlanetFollower>();
            Vector3 planetVelocity = follower.planets[follower.selectedPlanet].GetComponent<Rigidbody>().velocity;
            shotObject.GetComponent<Rigidbody>().velocity = startRay.direction * shotVelocity + planetVelocity;
            Debug.Log(shotObject.GetComponent<Rigidbody>().velocity);
        }
    }
}

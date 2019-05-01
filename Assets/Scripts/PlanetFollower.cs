using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlanetFollower : MonoBehaviour
{
    public Transform[] planets;
    public float followDistance = 2;
    public float transitionSpeed = 1;
    float transitionT;
    public int selectedPlanet { get; private set; }
    float positionDifference;
    Vector3 lastPosition;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        positionDifference = float.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedPlanet = (selectedPlanet + 1) % planets.Length;
            lastPosition = cam.transform.position;
            transitionT = 0;
            //positionDifference = float.MaxValue;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedPlanet = (selectedPlanet + planets.Length - 1) % planets.Length;
            lastPosition = cam.transform.position;
            transitionT = 0;
            //positionDifference = float.MaxValue;
        }
        //cam.transform.position = planets[selectedPlanet].position - cam.transform.forward * followDistance * planets[selectedPlanet].transform.lossyScale.magnitude;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = planets[selectedPlanet].position - cam.transform.forward * followDistance * planets[selectedPlanet].transform.lossyScale.magnitude;

        transitionT = Mathf.Lerp(transitionT, 1, Time.deltaTime * transitionSpeed);

        cam.transform.position = Vector3.Lerp(lastPosition, targetPosition, transitionT);

        /*if (Vector3.Distance(cam.transform.position, targetPosition) < positionDifference)
        {
            positionDifference = Vector3.Distance(cam.transform.position, targetPosition);
            //Lerp position
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        }
        else
        {
            positionDifference = -1;
            //Set position
            cam.transform.position = targetPosition;
        }*/


        /*Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;*/
    }
}

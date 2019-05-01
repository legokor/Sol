using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPullerManager : MonoBehaviour
{
    public float gravitationalConstant = 10;
    static ObjectPullerManager instance;
    public static float G => instance ? instance.gravitationalConstant : 0;

    void Awake()
    {
        if(instance)
        {
            Debug.LogError("There can be only one ObjectPullerManager.");
            Destroy(instance);
        }
        instance = this;
    }
}

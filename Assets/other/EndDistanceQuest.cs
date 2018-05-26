using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDistanceQuest : MonoBehaviour {

    public static bool isCameraViewToplayer;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "player")
        {
            Debug.Log("Check Starter");
            isCameraViewToplayer = true;
        }
    }
}

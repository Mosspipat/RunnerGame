using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest : MonoBehaviour {

    public static bool isCameraViewToplayer;

	void Start () {
        Transform Chest = GameObject.Find("chest").transform;		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "player")
        {
            isCameraViewToplayer = true;
            Debug.Log("playerCheck Victory");
        }
    }
}

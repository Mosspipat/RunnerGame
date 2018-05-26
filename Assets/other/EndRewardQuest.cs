using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRewardQuest : MonoBehaviour {

    public static bool isCameraViewToplayer;
    public static bool isCameraViewToViewOpenedBox;

	void Start () {
        Transform Chest = GameObject.Find("chest").transform;		
	}
	
    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "player")
        {
            isCameraViewToplayer = true;

            playerController.move = "walk";
        }
    }
}

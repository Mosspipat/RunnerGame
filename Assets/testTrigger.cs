using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour {
	
    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "player")
        {
            Debug.Log("hit Cube!");
        }
    }

    void OnDestroy() {
        print("Script was destroyed");
    }
}

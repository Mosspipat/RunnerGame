using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour {
	
    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "Cuba")
        {
            Debug.Log("hit Cube!");
        }
    }
}

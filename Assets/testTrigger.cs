using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour {
	
    /* public List <string> name = new List<string>();  
    public int number;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            name.Add("asdsad" + number.ToString());
            number++;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            name.Remove("asdsad"+3.ToString());
        }
    }*/

    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "player")
        {
            Debug.Log("hit Cube!");
        }
    }
}

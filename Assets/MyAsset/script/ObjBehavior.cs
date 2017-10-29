using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBehavior : MonoBehaviour {

    Animator AnimObj;

	void Start () {
        AnimObj = GetComponent<Animator>();
	}
	
    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (this.gameObject.name == "log"&&obj.name == "player")
        {
            AnimObj.SetTrigger("isHit");
        }
        if (this.gameObject.name == "headLog"&&obj.name == "player")
        {
            AnimObj.SetTrigger("isHit");
        }
    }
}

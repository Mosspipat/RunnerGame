using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 1f);
	}
	
	void Update () {
        this.transform.Translate(Vector3.forward*Time.deltaTime*20f);
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "enemy")
        {
            Debug.Log("kill enemy");
            Destroy(obj.gameObject);
            Destroy(this.gameObject);
        }
    }


}

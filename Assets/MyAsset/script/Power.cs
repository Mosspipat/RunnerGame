using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

    public GameObject effectImpact;

	void Start () {
        Destroy(this.gameObject, 3f);
        this.gameObject.name = "fireBall";
	}
	
	void Update () {
        this.transform.Translate(Vector3.forward*Time.deltaTime*20f);
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "enemy")
        {
            GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
            Destroy(smoke, 4f);
            Debug.Log("kill enemy");
            Destroy(obj.gameObject);
            Destroy(this.gameObject);
        }
        else if (obj.name == "Boss")
        {
            Destroy(this.gameObject);
            /* GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
            Destroy(smoke, 4f);*/
        }
    }


}

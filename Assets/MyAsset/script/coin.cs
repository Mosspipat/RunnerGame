using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

    GameObject player;
    float offsetBackwardPlayer = 10f;

	void Start () {
        player = GameObject.Find("player");
	}
	
	void Update () {
        this.transform.Rotate(new Vector3(Time.deltaTime*20f, 0, 0));
        DestroyitSelf();
	}

    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "player")
        {
            Destroy(this.gameObject);
        }
    }

    void DestroyitSelf()
    {
        if (this.gameObject.transform.position.z < player.transform.position.z - offsetBackwardPlayer)
        {
            Debug.Log("coin destroy");
            Destroy(this.gameObject);
        }
    }
}

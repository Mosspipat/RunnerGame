using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

    GameObject player;
    public GameObject CoinEffect;
    float offsetBackwardPlayer = 10f;

	void Start () {
        player = GameObject.Find("player");
	}
	
	void Update () {
        this.transform.Rotate(new Vector3(Time.deltaTime*100f, 0, 0));
        DestroyitSelf();
	}

    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "player")
        {
            GameObject effect = Instantiate(CoinEffect, this.transform.position, Quaternion.identity);
            Destroy(effect, 3f);
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

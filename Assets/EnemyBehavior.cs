using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public GameObject player;
	void Start () {
	}
	
	void Update () {
        player = GameObject.Find("player");
        FindTarget(player);
        /*this.transform.Translate(new Vector3(0, 0, 1f * Time.deltaTime));*/           //Transform to player;
	}

    void FindTarget(GameObject player)
    {
        this.transform.LookAt(player.transform.position);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public GameObject player;
	void Start () {
	}
	
	void Update () {
        FindTarget(player);
        this.transform.Translate(new Vector3(0, 0, 5f * Time.deltaTime));
	}

    void FindTarget(GameObject player)
    {
        this.transform.LookAt(player.transform.position);
    }

}

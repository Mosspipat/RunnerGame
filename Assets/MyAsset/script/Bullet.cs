﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

	void Start () {
		
	}
	
	void Update () {
        this.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        Destroy(this.gameObject, 10f);
	}

    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "player")
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slerpTest : MonoBehaviour {

    public Transform endPos;

	void Start () {
		
	}
	
	void Update () {
        this.transform.position = Vector3.Slerp(this.transform.position, endPos.position, 0.05f);
	}
}

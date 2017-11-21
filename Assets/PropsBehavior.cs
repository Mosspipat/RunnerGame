using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsBehavior : MonoBehaviour {

    Transform player;
    Animator AnimProp;

	void Start () {
        player = GameObject.Find("player").transform;
        AnimProp  = GetComponent<Animator>();
	}
	
	void Update () {
        CheckPlayerArrival();
	}

    #region CheckPlayerTrigger
    void CheckPlayerArrival()
    {
        if (player.transform.position.z > this.transform.position.z - 20f)
        {
            AnimProp.SetTrigger("isOpen");
        }
    }
    #endregion
}

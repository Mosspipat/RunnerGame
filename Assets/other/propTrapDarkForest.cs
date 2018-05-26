using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propTrapDarkForest : MonoBehaviour {

    int rangeOffset = 10;

	void Start () {
		
	}
	
	void Update () {
        TrapWorking();
	}

    public void TrapWorking()
    {
        if (GameObject.Find("player").transform.position.z > this.transform.position.z - rangeOffset )
        {
            this.transform.Find("prop").GetComponent<Animator>().SetTrigger("isMove");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropTrapRedvolcano : MonoBehaviour {

    int rangeOffset = 10;

    void Update () {
        TrapWorking();
    }

    public void TrapWorking()
    {
        if (GameObject.Find("player").transform.position.z > this.transform.position.z - rangeOffset )
        {
            this.GetComponent<Animator>().SetTrigger("isFall");
        }
    }
}

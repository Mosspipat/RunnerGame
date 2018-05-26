using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour {

    public GameObject[] fallenTrap;
    bool canFallObject  = true;
    int rangeOffset = 20;

    void Update()
    {
        AnimationOpen();
    }


    void AnimationOpen()
    {
        if (GameObject.Find("player").transform.position.z > this.transform.position.z - rangeOffset && canFallObject)
        {
            canFallObject = false;
            this.transform.Find("prop").GetComponent<Animator>().SetTrigger("isOpen");
        }
    }
}

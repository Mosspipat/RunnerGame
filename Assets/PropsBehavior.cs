using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsBehavior : MonoBehaviour {

    playerController pc;
    Transform player;
    Animator AnimProp;

    Transform TotalScoreUI;

	void Start () {
        TotalScoreUI = GameObject.Find("Main Camera/ProgressPlayer/totalScore").transform;
        pc = GameObject.Find("player").GetComponent<playerController>();
        player = GameObject.Find("player").transform;
        AnimProp  = GetComponent<Animator>();
	}
	
	void Update () {
        CheckPlayerArrival();
	}

    #region CheckPlayerTrigger
    void CheckPlayerArrival()
    {
        //if player pos is throw the castle's trigger
         if (player.transform.position.z > this.transform.position.z - 20f && player.transform.position.z < this.transform.position.z && this.name == "Fortress")
        {
           player.position = new Vector3(GameObject.Find("castlePlatform/Fortress/stopPoint").transform.position.x,player.transform.position.y,player.transform.position.z);
            AnimProp.SetTrigger("isOpen");
        }
        else if (player.transform.position.z > this.transform.position.z  && this.name == "Fortress")
        {
            AnimProp.SetTrigger("isClose");
            playerController.move = "walkToCastle";
        }

        //anyObject
        // if player pos is infront of the gate
        if (player.transform.position.z > this.transform.position.z - 20f && player.transform.position.z < this.transform.position.z)
        {
            AnimProp.SetTrigger("isOpen");
        }
    }
    #endregion

    #region AnimationEvent Props
    void AnimationProp()
    {
        TotalScoreUI.gameObject.SetActive(true);
        playerController.EndStage = true;
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventBoss : MonoBehaviour {

    public Transform leftHand;
    public Transform rightHand;

    public GameObject power;

    public Vector3 newTargetPlayerPosition;

    public bool ChecklastPlayerPosition =true;
    string action;
    public static bool isAttacked = false;
    public static bool isTired = false;

    GameObject player;
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        leftHand.LookAt(player.transform.position);
        rightHand.LookAt(player.transform.position);
        Action();
	}

    #region Animation's CheckPoint

    public void ThrowPowerLeftHand()
    {
        action = "isGoback";
        Instantiate(power, leftHand.transform.position,leftHand.transform.rotation);
    }

    public void ThrowPowerRightHand()
    {
        Instantiate(power, rightHand.transform.position,rightHand.transform.rotation);
    }

    public void CheckJump()
    {
        action = "jump";
        newTargetPlayerPosition = GameObject.Find("player").transform.position;
    }

    public void CheckisJumpAttack()
    {
        action = "isJumpAttack";
    }

    public void ShootDirectPower()
    {
        action = "isGoback";
        Instantiate(power, leftHand.transform.position,leftHand.transform.rotation);
        Instantiate(power, rightHand.transform.position,rightHand.transform.rotation);
    }
    public void IsAttacked()
    {
        isAttacked = true;
    }
    public void FinishIsAttacked()
    {
        isAttacked = false;
    }
    /*public void Tired()
    {
        action = "isGoback"; 
        isTired = true;
    }
    public void FinishTired()
    {
        isTired = false;
    }*/
    #endregion

    #region Boss's Control move
    void Action()
    {
        if (action == "jump")
        {
            this.transform.position = Vector3.Lerp(this.transform.position, newTargetPlayerPosition + Vector3.up * 10f, 0.1f);
        }
        else if (action == "isJumpAttack")
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(newTargetPlayerPosition.x,
                    player.transform.position.y+1.3f,
                    player.transform.position.z), 0.5f);
        }
        else if (action == "isGoback")
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-0.71f, GameObject.Find("player").transform.position.y + 5f, GameObject.Find("player").transform.position.z + 15f), 0.1f);
        }
    }
    #endregion
}

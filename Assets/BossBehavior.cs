using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;

public class BossBehavior : MonoBehaviour {

    public GameObject headBoss;
    Transform bodyBoss;

    public static bool isBossApprea;
    void Start () 
    {
        isBossApprea = true;
        bodyBoss = this.transform.Find("boss/body").transform;
        this.transform.position = new Vector3(-0.71f, GameObject.Find("player").transform.position.y + 5f, GameObject.Find("player").transform.position.z - 15f);
    }
    
    void Update () {

        startAppreaPositionBoss();
      
        headBoss.transform.LookAt(GameObject.Find("player").transform.position);
        if (AnimationEventBoss.isAttacked == false)                             //check when boss was hit let "head" move with animation
        {
            headBoss.transform.position = bodyBoss.transform.position + Vector3.up * 1.5f;
        }
        /*if(AnimationEventBoss.isTired == true )
        {
            headBoss.transform.rotation = this.transform.rotation * Quaternion.Euler(2,0,0);
            //headBoss.transform.rotation = Quaternion.Slerp(this.transform.rotation,this.transform.localRotation * Quaternion.Euler(45,45,45),Time.deltaTime);
        }*/
	}

    void startAppreaPositionBoss()
    {
        if (isBossApprea == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-0.71f,GameObject.Find("player").transform.position.y+5f,GameObject.Find("player").transform.position.z+15f),0.1f );
        }
        else
        {
            this.transform.position = new Vector3(-0.71f,GameObject.Find("player").transform.position.y+5f,GameObject.Find("player").transform.position.z+15f);
        }
    }
}

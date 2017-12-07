﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform playerPosition;
    Vector3 startOffsset = new Vector3(0,4,-4f); 
    Vector3 moveVector;

    float transition = 0f;
    float animationDuration = 2f;
    Vector3 animationOffset = new Vector3(0,5,60);

    public bool lowHealth{set; get;}
    bool isPosion = true;
    public bool isSpeed { set; get; }
    List<Quaternion> positionLerp;                         //lerp EulerView for Shake Camera

    void Start()
    {
        playerPosition = GameObject.Find("player").transform;

        positionLerp = new List<Quaternion>();
        positionLerp.Add(Quaternion.Euler(0,20,0));
        positionLerp.Add(Quaternion.Euler(20,0,0));
        positionLerp.Add(Quaternion.Euler(0,-20,0));
        positionLerp.Add(Quaternion.Euler(-20,0,0));
    }


	void Update () {
        moveVector = playerPosition.position + startOffsset;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);                     //fix camera not out allow between the Y;
        if (transition>1 &&isSpeed == false && BossBehavior.isLookatBoss == false &&EndQuest.isCameraViewToplayer == false)
        {
            /*moveVector.x = -0.5f;*/                                               //Fix camera to zero not follow player move
            moveVector.y = 3f;
            /*transform.position = moveVector;*/
            transform.position = Vector3.Lerp(this.transform.position, moveVector, Time.deltaTime * 5);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(10, 0, 0), Time.deltaTime);    //return To SamePoint form hit action
        }

         #region Camera SpeedEffect
        else if ( isSpeed == true)
        {
            transform.position = Vector3.Lerp(this.transform.position, moveVector + Vector3.forward * 3 - Vector3.up * 2, Time.deltaTime * 5); 
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(10, 0, 0), Time.deltaTime);
            Invoke("SpeedEffect", 5f);
        }
        #endregion

        #region Camera LookatBoss
        else if (BossBehavior.isLookatBoss == true)
        {
            transform.position = Vector3.Lerp(this.transform.position, moveVector + Vector3.forward * 3 - Vector3.up * 2, Time.deltaTime * 5); 
            this.transform.LookAt(GameObject.Find("boss").transform.position);
            Invoke("lookatBoss", 10f);
        }
        #endregion

        #region Camera Lookat QuestComplete
        else if (EndQuest.isCameraViewToplayer == true && EndQuest.isCameraViewToViewOpenedBox == false)
        {
            this.transform.position = GameObject.Find("victoryPlatform/chest").transform.position + Vector3.up * 2f + Vector3.forward *4f;
            this.transform.LookAt(playerPosition.position);
        }
        else if (EndQuest.isCameraViewToViewOpenedBox == true)
        {
            
            this.transform.RotateAround(GameObject.Find("victoryPlatform/chest").transform.position, Vector3.up, 10f * Time.deltaTime);
            this.transform.LookAt(playerPosition.position + (Vector3.up*2.5f));
        }
        #endregion
        #region Camera LookatPlayer
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(playerPosition.position + (Vector3.up*2.5f));
        }
        #endregion
        /* #region low HealthEffect
        else if( lowHealth == true &&isPosion == true)                                              //Later test Effect Camera
        {
            isPosion = false;
            moveVector.y = 3f;
            transform.position = moveVector;

            int newViewCameraLook = Random.Range(0, 4);
            this.transform.rotation =  Quaternion.Slerp(transform.rotation,positionLerp[newViewCameraLook], Time.deltaTime*50);
            Debug.Log("new Cameara Change++++++++++++++++++++++++++++++++++++++++++++");
            Invoke("LowHealthEffect",2f);
        }
        #endregion*/
	}

    #region CameraEffect
    public void ShakeCamera()
    {
        int motionCamera = Random.Range(1, 4);
        switch (motionCamera)
        {
            case 1 : 
                this.transform.rotation =  Quaternion.Lerp(transform.rotation,Quaternion.Euler(45,45,45), Time.deltaTime*30);
                break;
            case 2 : 
                this.transform.rotation =  Quaternion.Lerp(transform.rotation,Quaternion.Euler(-45,-45,45), Time.deltaTime*30);
                break;
            case 3 : 
                this.transform.rotation =  Quaternion.Lerp(transform.rotation,Quaternion.Euler(-45,45,-45), Time.deltaTime*30);
                break;
        }
    }

    /*public void LowHealthEffect()                 //Later test Effect Camera Invoke
    {
        isPosion = true;
    }*/

    public void SpeedEffect()                 //Later test Effect Camera Invoke
    {
        isSpeed = false;
    }
    public void lookatBoss()
    {
        BossBehavior.isLookatBoss = false;
    }
    #endregion
}

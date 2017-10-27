using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform playerPosition;
    Vector3 startOffsset = new Vector3(0,4,-4f); 
    Vector3 moveVector;

    float transition = 0f;
    float animationDuration = 2f;
    Vector3 animationOffset = new Vector3(0,5,60);

    public bool lowHealth{ set; get;}
    bool isPosion = true;
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
        if (transition > 1f )         //adddition lowHealth = false     /*&& isPosion == false*/
        {
            /*moveVector.x = -0.5f;*/                                               //Fix camera to zero not follow player move
            moveVector.y = 3f;
            transform.position = moveVector;
            this.transform.rotation =  Quaternion.Slerp(transform.rotation,Quaternion.Euler(10,0,0), Time.deltaTime);    //return To SamePoint form hit action
        }

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

        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(playerPosition.position + (Vector3.up*2.5f));
        }
	}

    #region CameraEffect
    public void ShakeCamera()
    {
        int motionCamera = Random.Range(1, 4);
        switch (motionCamera)
        {
            case 1 : 
                this.transform.rotation =  Quaternion.Slerp(transform.rotation,Quaternion.Euler(45,45,45), Time.deltaTime*30);
                break;
            case 2 : 
                this.transform.rotation =  Quaternion.Slerp(transform.rotation,Quaternion.Euler(-45,-45,45), Time.deltaTime*30);
                break;
            case 3 : 
                this.transform.rotation =  Quaternion.Slerp(transform.rotation,Quaternion.Euler(-45,45,-45), Time.deltaTime*30);
                break;
        }
    }

    /*public void LowHealthEffect()                 //Later test Effect Camera Invoke
    {
        isPosion = true;
    }*/

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform playerPosition;
    Vector3 startOffsset = new Vector3(0,4,-4f); 
    Vector3 moveVector;

    float transition = 0f;
    float animationDuration = 2f;
    Vector3 animationOffset = new Vector3(0,5,60);

	void Update () {
        moveVector = playerPosition.position + startOffsset;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);                     //fix camera not out allow between the Y;
        if (transition>1f)
        {
            moveVector.x = -0.5f;                                               //Fix camera to zero not follow player move
            transform.position = moveVector;                                                            
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(playerPosition.transform.position + (Vector3.up*1.5f));
        }

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKinectController : MonoBehaviour {

    public string isMoving{ get; set;}
    public bool isJumping{ get; set;}
    public bool isSliding{ get; set;}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckMove();
	}

    void CheckMove()
    {
        switch (isMoving)
        {
            case "moveLeft":
                Debug.Log("moveLeft");
                break;
            case "moveRight":
                Debug.Log("moveRight");
                break;
            case "jump":
                Debug.Log("moveJump");
                break;
            case "slide":
                Debug.Log("moveSlide");
                break;
        }
    }
}

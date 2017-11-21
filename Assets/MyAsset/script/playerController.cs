﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public Terrain TerrianPlayerFirst;
    public Terrain TerrianPlayerSecond;
    float PosbeforeTerrianPlayerFirst= 400;
    float PosbeforeTerrianPlayerSecond = 200;
    float nextMoveTerrianZ = 400f;

    public bool isDead{ set; get; }

    Rigidbody RBPlayer;
    CharacterController controlCha;
    BoxCollider BCPlayer;
    Progressbar PBplayer;
    public float forceSpeed;
    Vector3 moveVector;
    float gravity = 12.5f;
    float verticalVelpcity;

    string way;
    public Vector3 presentWay;
    public float leftWay = -2.5f;
    public float rightWay = 2.5f;
    private float positionJump;

    private Transform playerWay;

    float offsetPlayerMin;
    float offsetPlayerMax;

    Animator AnimPlayer;
    Animator AnimUIHit;
    Animator AnimUILowHealth;

    public GameObject power;
    public Transform spawnPowerPoint;

    CameraController CC;

	void Start () {
        RBPlayer = this.transform.GetComponent<Rigidbody>();
        controlCha = this.transform.GetComponent<CharacterController>();
        PBplayer = GameObject.Find("Main Camera").transform.GetChild(0).GetComponent<Progressbar>();
        BCPlayer = this.transform.GetComponent<BoxCollider>();
        this.transform.position = new Vector3(0f,this.transform.position.y,this.transform.position.z);
        way = "middle";

        offsetPlayerMin = this.transform.position.x - 2.5f;
        offsetPlayerMax = this.transform.position.x + 2.5f;
        Debug.Log(offsetPlayerMin);
        Debug.Log(offsetPlayerMax);

        AnimPlayer = GetComponent<Animator>();
        AnimUIHit = GameObject.Find("Main Camera").transform.GetChild(0).GetChild(2).GetComponent<Animator>();
        AnimUILowHealth = GameObject.Find("Main Camera").transform.GetChild(0).GetChild(3).GetComponent<Animator>();

        CC = GameObject.Find("Main Camera").GetComponent<CameraController>();
	}
	
	void Update () {
        Controller();
        moveVector = new Vector3(0, verticalVelpcity, 0);                               //move vector.y
        moveVector.z = forceSpeed;                                              //move vector.z 
        controlCha.Move(moveVector * Time.deltaTime);                           //addforce version playerController
        MoveTerrianFollowPlayer();

        LerpChangeWay(presentWay);
      
        transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, offsetPlayerMin, offsetPlayerMax), this.transform.position.y, this.transform.position.z);       //Clamp posX;

    }
 
    void Controller()
    {
        /* moveSide = Input.GetAxis("Horizontal");*/

        // Middle Move 
        if (Input.GetKeyDown(KeyCode.A)&& way == "middle")
        {
            presentWay = new Vector3(this.transform.position.x + leftWay,this.transform.position.y,this.transform.position.z);
            way = "left";
            Debug.Log("goLeftWay");
            Debug.Log(offsetPlayerMin);
            AnimPlayer.SetTrigger("isLeft");
        }
        if (Input.GetKeyDown(KeyCode.D)&& way == "middle")
        {
            presentWay = new Vector3(this.transform.position.x + rightWay,this.transform.position.y,this.transform.position.z);
            way = "right";
            Debug.Log("goRightWay");
            Debug.Log(offsetPlayerMax);
            AnimPlayer.SetTrigger("isRight");
        }
        // Left Move
        if (Input.GetKeyDown(KeyCode.D)&& way == "left")
        {
            presentWay = new Vector3(this.transform.position.x + rightWay,this.transform.position.y,this.transform.position.z);
            way = "middle";
            Debug.Log("goMiddleWay");
            AnimPlayer.SetTrigger("isRight");
        }

        // Right Move
        if (Input.GetKeyDown(KeyCode.A)&& way == "right")
        {
            presentWay = new Vector3(this.transform.position.x + leftWay,this.transform.position.y,this.transform.position.z);
            way = "middle";
            Debug.Log("goMiddleWay");
            AnimPlayer.SetTrigger("isLeft");
        }

        /*if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("slide");
            // player play animation slide;
        }*/

        if (controlCha.isGrounded)                                                  
        {
            verticalVelpcity = -gravity * Time.deltaTime;                   //add gravity to velcity
            if (Input.GetKeyDown(KeyCode.Space))                        
            {
                verticalVelpcity = 4f;                                  // add velocity in single frame
                StartJump();
                Invoke("StopJump",0.6f);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                StartSlide();
                Invoke("StopSlide", 1);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                AnimPlayer.SetTrigger("isAttack");
                Instantiate(power, spawnPowerPoint.transform.position, spawnPowerPoint.transform.rotation);

                /*moveVector.z = 0;
                controlCha.enabled =false;
                Invoke("StartRun", 1f);*/
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.transform.position = this.transform.position + new Vector3(0, 0, 5f);
                /*moveVector.z = 0;
                controlCha.enabled =false;
                Invoke("StartRun", 1f);*/
            }
        }
        else
        {
            verticalVelpcity -= gravity * Time.deltaTime;               //add  gravity to velocity 
        }
    }


    #region LerpMove
    void LerpChangeWay(Vector3 newWay)
    {
        /*if (newWay == JumpWay)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,new Vector3 (this.transform.position.x,positionJump,this.transform.position.z), 5f);
        }
        else */   
        this.transform.position = Vector3.Lerp(this.transform.position,new Vector3 (newWay.x,this.transform.position.y,this.transform.position.z), 0.3f);
    }
    #endregion
    /* #region stativMove
    void ChangeWay(Transform newWay)
    {
        this.transform.position = new Vector3 (newWay.transform.position.x,this.transform.position.y,this.transform.position.z); 
    }
    #endregion*/

    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "item")
        {
            Destroy(obj.gameObject);
            Time.timeScale = 2;
        }
        else if (obj.name == "obstacle_tree")
        {
            Application.LoadLevel("gameover");
            isDead = true;
        }
        else if (obj.name == "coin")
        {
            Debug.Log("get coin");
            Destroy(obj);
        }
        else if (obj.name == "log")
        {
            Debug.Log("Log hit Leg");
            PBplayer.GetDamage(1);
            AnimPlayer.SetTrigger("isLegHit");
            BangAnimation();
        }
        else if (obj.name == "headLog")
        {
            Debug.Log("Log hit Head");
            PBplayer.GetDamage(1);
            AnimPlayer.SetTrigger("isHeadHit");
            BangAnimation();
        }
        else if (obj.tag == "enemy"||obj.tag == "trap")
        {
            Debug.Log("enemy hit Player");
            PBplayer.GetDamage(1);
            AnimPlayer.SetTrigger("isLegHit");
            BangAnimation();
        }
        else if (obj.name == "bullet")
        {
            Debug.Log("bullet hit Player");
            PBplayer.GetDamage(1);
            AnimPlayer.SetTrigger("isLegHit");
            BangAnimation();
        }
    }

    void MoveTerrianFollowPlayer()
    {
        if (this.transform.position.z >= PosbeforeTerrianPlayerSecond)
        {
            PosbeforeTerrianPlayerSecond += nextMoveTerrianZ;
            TerrianPlayerFirst.transform.position = new Vector3(TerrianPlayerFirst.transform.position.x,
                TerrianPlayerFirst.transform.position.y,
                PosbeforeTerrianPlayerFirst);
            
        }
        if (this.transform.position.z >= PosbeforeTerrianPlayerFirst)
        {
            PosbeforeTerrianPlayerFirst += nextMoveTerrianZ;
            TerrianPlayerSecond.transform.position = new Vector3(TerrianPlayerSecond.transform.position.x,
                TerrianPlayerSecond.transform.position.y,
                PosbeforeTerrianPlayerSecond);
        }
    }
    #region actionControl
    void StartSlide()
    {
        AnimPlayer.SetTrigger("isSlide");
        controlCha.center = new Vector3(controlCha.center.x,controlCha.center.y/2,controlCha.center.z);
        controlCha.height /= 2;
    }

    void StopSlide()
    {
        controlCha.center = new Vector3(controlCha.center.x,controlCha.center.y*2,controlCha.center.z);
        controlCha.height *= 2;
    }

    void StartJump()
    {
        AnimPlayer.SetTrigger("isJump");
        BCPlayer.center *= 2;
        controlCha.center = new Vector3(controlCha.center.x,controlCha.center.y*1.5f,controlCha.center.z);
        controlCha.height /= 2;
    }

    void StopJump()
    {
        BCPlayer.center /= 2;
        controlCha.center = new Vector3(controlCha.center.x,controlCha.center.y/1.5f,controlCha.center.z);
        controlCha.height *= 2;
    }

    void StartRun()
    {
        controlCha.enabled = true;
    }
    #endregion

    #region UIAnimation
    void BangAnimation()
    {
        AnimUIHit.SetTrigger("isHit");
        CC.ShakeCamera();
    }
    public void StartLowHealthAnimation()
    {
        AnimUILowHealth.SetBool("isLowHealth", true);
    }
    public void StopLowHealthAnimation()
    {
        AnimUILowHealth.SetBool("isLowHealth", false);
    }

    #endregion
}

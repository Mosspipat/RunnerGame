using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public Terrain TerrianPlayerFirst;
    public Terrain TerrianPlayerSecond;
    float PosbeforeTerrianPlayerFirst= 400;
    float PosbeforeTerrianPlayerSecond = 200;
    float nextMoveTerrianZ = 400f;


    Rigidbody RBPlayer;

    [HideInInspector]
    public CharacterController controlCha;

    BoxCollider BCPlayer;
    Progressbar UIBarPlayer;
    public float maxForceSpeed;
    public static float forceSpeed;
    Vector3 moveVector;
    float gravity = 12.5f;
    float verticalVelpcity;

    public static string move;

    string way;
    public Vector3 presentWay;
    public float leftWay = -2.5f;
    public float rightWay = 2.5f;
    private float positionJump;

    private Transform playerWay;

    float offsetPlayerMin;
    float offsetPlayerMax;

    [HideInInspector]
    public Animator AnimPlayer;
    Animator AnimUIHit;
    Animator AnimUILowHealth;

    public GameObject power;
    public Transform spawnPowerPoint;

    CameraController CC;

    public static int maxPowerAttack = 5;
    public static int maxPowerDefence = 5;
    public static int powerAttack = 5;
    public static int powerDefence = 5;
    bool kill;
    bool block;
    public GameObject effectImpact;

    public bool isShield;
    public static float timeShield = 5f;
    public bool isQuickRun;
    public static float timeQuick = 3f;
    public static bool isMagnetEffect;
    public static float timeMagnet = 10f;

    public GameObject particleShield;
    public GameObject particleQuickRun;


    public static bool EndStage;

	void Start () {
        RBPlayer = this.transform.GetComponent<Rigidbody>();
        controlCha = this.transform.GetComponent<CharacterController>();
        UIBarPlayer = GameObject.Find("Main Camera/ProgressPlayer").GetComponent<Progressbar>();
        BCPlayer = this.transform.GetComponent<BoxCollider>();
        this.transform.position = new Vector3(0f,this.transform.position.y,this.transform.position.z);
        way = "middle";

        offsetPlayerMin = this.transform.position.x - 2.5f;
        offsetPlayerMax = this.transform.position.x + 2.5f;
        /*Debug.Log(offsetPlayerMin);
        Debug.Log(offsetPlayerMax);*/

        move = "run";

        AnimPlayer = GetComponent<Animator>();

        AnimUIHit = GameObject.Find("Main Camera/ProgressPlayer/damageImage").transform.GetComponent<Animator>();
        AnimUILowHealth = GameObject.Find("Main Camera/ProgressPlayer/lowHealthImage").transform.GetComponent<Animator>();

        CC = GameObject.Find("Main Camera").GetComponent<CameraController>();
        isShield = false;
	}
	
	void Update () {
        Controller();
        Move();
        MoveTerrianFollowPlayer();
        ChangeTargetReleasePower();

        LerpChangeWay(presentWay);

        ShiledProtectAnimation();
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
            //Debug.Log("goLeftWay");
            AnimPlayer.SetTrigger("isLeft");
        }
        if (Input.GetKeyDown(KeyCode.D)&& way == "middle")
        {
            presentWay = new Vector3(this.transform.position.x + rightWay,this.transform.position.y,this.transform.position.z);
            way = "right";
            //Debug.Log("goRightWay");
            AnimPlayer.SetTrigger("isRight");
        }
        // Left Move
        if (Input.GetKeyDown(KeyCode.D)&& way == "left")
        {
            presentWay = new Vector3(this.transform.position.x + rightWay,this.transform.position.y,this.transform.position.z);
            way = "middle";
            //Debug.Log("goMiddleWay");
            AnimPlayer.SetTrigger("isRight");
        }

        // Right Move
        if (Input.GetKeyDown(KeyCode.A)&& way == "right")
        {
            presentWay = new Vector3(this.transform.position.x + leftWay,this.transform.position.y,this.transform.position.z);
            way = "middle";
            //Debug.Log("goMiddleWay");
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
            if (Input.GetKey(KeyCode.W))
            {
                /* for (int quickjumpForward = 0; quickjumpForward < 5; quickjumpForward++)
                {
                    this.transform.position = this.transform.position + new Vector3(0, 0, 1f);
                }*/
                controlCha.Move(new Vector3(0, 0, 10f) * Time.deltaTime);
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


    void Move()
    {
        moveVector = new Vector3(0, verticalVelpcity, 0);                               //move vector.y

        forceSpeed += 10 * Time.deltaTime;
        if (move == "run")
        {
            moveVector.z = forceSpeed;                                              //move vector.z 
            controlCha.Move(moveVector * Time.deltaTime);                           //addforce version playerController
        }
        if (move == "fastRun")
        {
            moveVector.z = forceSpeed*1.3f;                                              //move vector.z 
            controlCha.Move(moveVector * Time.deltaTime);                           //addforce version playerController
        }

        else if (move == "walk")
        {
            moveVector.z = 0;                                              //move vector.z 
            controlCha.Move(moveVector * Time.deltaTime);                           //addforce version playerController

            this.transform.position = Vector3.Lerp(this.transform.position, GameObject.Find("victoryPlatform/chest/searchRewardPoint").transform.position, 0.01f);
            AnimPlayer.SetTrigger("isWalk");
        }
        else if (move == "walkToCastle")
        {
            moveVector.z = 0;                                              //move vector.z 
            controlCha.Move(moveVector * Time.deltaTime);                           //addforce version playerController
            this.transform.position = GameObject.Find("castlePlatform/Fortress/stopPoint").transform.position;
            /* this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(GameObject.Find("castlePlatform/Fortress/stopPoint").transform.position.x,
                GameObject.Find("castlePlatform/Fortress/stopPoint").transform.position.y,
                GameObject.Find("castlePlatform/Fortress/stopPoint").transform.position.z), 0.01f);*/
            AnimPlayer.SetTrigger("isWalk");
        }
        else if (move == "stop")
        {
            moveVector.z = 0; 
        }
        // Check force Speed
        if (forceSpeed >= maxForceSpeed)                                            // make simple forceSpeed to move
        {
            forceSpeed = maxForceSpeed;
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

    #region Check hit Player
    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "bariaItem")
        {
            isShield = true;
            particleShield.SetActive(true);
            Invoke("StopShield", timeShield);
            Destroy(obj.gameObject);
        }
        else if ((obj.tag == "enemy" || obj.tag == "obstacle") && isShield == true||isQuickRun == true)
        {
            Debug.Log("shield protection");
            particleShield.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);  
            GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
            Destroy(smoke, 4f);
            Destroy(obj.gameObject);
        }
        else if (obj.name == "speedItem")
        {
            CC.isSpeed = true;
            move = "fastRun";
            particleQuickRun.SetActive(true);
            Invoke("NormalMove", timeQuick);
            Destroy(obj.gameObject);
        }
        else if (obj.name == "magnetItem")
        {
            Debug.Log("magnet Get!!");
            Destroy(obj.gameObject);
            isMagnetEffect = true;
            Invoke("StopMagnet", timeMagnet);
        }
        else if (obj.name == "posionItem")
        {
            Progressbar.health++;
            Destroy(obj.gameObject);
        }
        else if (!isShield)
        {
         if (obj.name == "obstacle_tree")
        {
            /*Application.LoadLevel("gameover");*/
            /*isDead = true;*/
            forceSpeed = -7f;
            UIBarPlayer.GetDamage(1);
            AnimPlayer.SetTrigger("isLegHit");
            BangAnimation();
        }
        else if (obj.name == "coin")
        {
            Debug.Log("get coin");
            Destroy(obj);
        }
        else if (obj.name == "log")
        {
            Debug.Log("Log hit Leg");
            UIBarPlayer.GetDamage(1);
            AnimPlayer.SetTrigger("isLegHit");
            BangAnimation();
        }
        else if (obj.name == "headLog")
        {
            Debug.Log("Log hit Head");
            UIBarPlayer.GetDamage(1);
            AnimPlayer.SetTrigger("isHeadHit");
            BangAnimation();
        }
        else if (obj.tag == "enemy")
        {
            Debug.Log("Challenge Fight");
            if (powerAttack >= obj.GetComponent<EnemyBehavior>().power)
            {
                AnimPlayer.SetTrigger("isAttack");
                transform.Find("UIPlayer/statusIcon").transform.GetComponent<Image>().sprite = Resources.Load("UIPlayer/attackIcon",typeof(Sprite)) as Sprite; 
                transform.Find("UIPlayer/statusIcon").transform.GetComponent<Animator>().SetTrigger("isAttack");
            }
            else if (powerAttack < obj.GetComponent<EnemyBehavior>().power)
            {
                int damageRemain = obj.GetComponent<EnemyBehavior>().power - powerAttack;
                if (powerDefence >= damageRemain)
                {
                    AnimPlayer.SetTrigger("isBlock");
                    transform.Find("UIPlayer/statusIcon").transform.GetComponent<Image>().sprite = Resources.Load("UIPlayer/defenceIcon",typeof(Sprite)) as Sprite; 
                    transform.Find("UIPlayer/statusIcon").transform.GetComponent<Animator>().SetTrigger("isDefence");
                }
                else
                {
                    powerAttack = 0;
                    int damageToPlayer = powerDefence - damageRemain;
                    UIBarPlayer.GetDamage(Mathf.Abs(damageToPlayer));
                    powerDefence = 0;
                    AnimPlayer.SetTrigger("isLegHit");
                    transform.Find("UIPlayer/statusIcon").transform.GetComponent<Image>().sprite = Resources.Load("UIPlayer/damageIcon",typeof(Sprite)) as Sprite; 
                    transform.Find("UIPlayer/statusIcon").transform.GetComponent<Animator>().SetTrigger("isDamage");

                    GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
                    Destroy(smoke, 4f);
                    Destroy(obj.gameObject);
                }
            }
            /* else
            {
                UIBarPlayer.GetDamage(1);
                AnimPlayer.SetTrigger("isLegHit");
                BangAnimation();

            }*/
        }

        else if (obj.tag == "trap")
        {
            Debug.Log("enemy hit Player");
            UIBarPlayer.GetDamage(1);
            AnimPlayer.SetTrigger("isLegHit");
            BangAnimation();
        }
        else if (obj.name == "bullet")
        {
            if (Progressbar.health <= 0)
            {
                AnimPlayer.SetTrigger("isDead");
            }
            else
            {
                UIBarPlayer.GetDamage(1);
                AnimPlayer.SetTrigger("isLegHit");
                BangAnimation();
            }
        }
        else if( obj.name == "searchRewardPoint")
        {
            Debug.Log("root BoxChest");
            AnimPlayer.SetTrigger("isSearch");
        }
        else if( obj.name == "mapTreasure")
        {
            Debug.Log("get mapTreasure");
            Progressbar.amountTreasureInt++;
        }
        else if( obj.name == "platform_Transport")
        {
            Debug.Log("get mapTreasure");
            Progressbar.amountTreasureInt++;
        }
        else if( obj.name == "ItemAttack")
        {
            Debug.Log("Att+");
            powerAttack++;
        }
        else if( obj.name == "ItemDefence")
        {
            Debug.Log("Def+");
            powerDefence++;
        }
        }
    }
    #endregion

    #region OnTriggerStay
    void OnTriggerStay(Collider obj) {
        if (obj.tag == "enemy")
        {
            if (kill)
            {
                UIPlayer.amountMonsterKilled++;
                if (powerAttack < obj.GetComponent<EnemyBehavior>().power)
                {
                    powerAttack = 0;
                }
                else
                {
                    powerAttack -= obj.GetComponent<EnemyBehavior>().power;
                }
                GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
                Destroy(smoke, 4f);
                Destroy(obj.gameObject);
            }

            else if(block)
            {
                int damageRemain = obj.GetComponent<EnemyBehavior>().power - powerAttack;
                powerAttack = 0;
                powerDefence -= damageRemain;
                UIPlayer.amountMonsterKilled++;
                GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
                Destroy(smoke, 4f);
                Destroy(obj.gameObject);
            }
        }
    }
    #endregion

    #region main Terrian Follow with player
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

    void ChangeTargetReleasePower()
    {
        if (BossBehavior.isBossApprea == true)
        {
            spawnPowerPoint.LookAt(GameObject.Find("boss").transform.position); //**Change to look at boss not for press R
        }
        else 
        {
            spawnPowerPoint.transform.rotation = new Quaternion(0,0,0,0);             
        }
    }
    #endregion

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

    void NormalMove()
    {
        move = "run";
        CC.isSpeed = false;
        particleQuickRun.SetActive(false);
    }
    #endregion

    #region UIAnimation && ParticleAnimation
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

    public void ShiledProtectAnimation()
    {
        particleShield.transform.localScale = Vector3.Lerp(particleShield.transform.localScale, new Vector3(1f, 1f, 1f),2f*Time.deltaTime); 
    }

    void StopShield()
    {
        isShield = false;
        particleShield.SetActive(false);
    }

    void StopMagnet()
    {
        isMagnetEffect = false;
    }
    #endregion

    #region PlayerAnimationEvents
    public void OpenLootBox()
    {
        Debug.Log("open LootBox");
        Animator animChest = GameObject.Find("victoryPlatform/chest").transform.GetComponent<Animator>();
        EndRewardQuest.isCameraViewToViewOpenedBox = true;

        Transform CameraView = Camera.main.transform;
        CameraView.transform.position = GameObject.Find("victoryPlatform/chest/viewPointRotation").transform.position;

        animChest.SetTrigger("isOpen");
    }
    public void Kill()
    {
        kill = true;
    }
    public void EndKill()
    {
        kill = false;   
    }

    public void Block()
    {
        block = true;
    }

    public void EndBlock()
    {
        block = false;
    }
    public void Dead()
    {
        Application.LoadLevel("gameover");
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    AudioSource soundManagerPlayer;
    public List<AudioClip> soundStore;

    UIPlayer uiPlayer;

    int LevelPlayer;

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

    public static int maxPowerAttack;
    public static int maxPowerDefence;
    public static int powerAttack;
    public static int powerDefence;
    bool kill;
    bool block;
    public GameObject effectImpact;

    public bool isShield;
    public bool isQuickRun;
    public static bool isMagnetEffect;

    public static float timeShield ;
    public static float timeQuick ;
    public static float timeMagnet ;

    public GameObject particleShield;
    public GameObject particleQuickRun;

    public static bool EndStage;

    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    public List<GameObject> swordType;
    public List<GameObject> shieldType;
    public List<Transform> posEquip;

    int equipSet;
    int attackWeapon;
    int defenceWeapon;

    void Start () {

        soundManagerPlayer = GetComponent<AudioSource>();

        uiPlayer = GameObject.Find("player/UIPlayer").GetComponent<UIPlayer>();

        LevelPlayer = PlayerPrefs.GetInt("levelPlayer");

        CheckStatusWeaponEquip();
        StarterStatus();
        equipWeapon();
        EndStage = false;

        RBPlayer = this.transform.GetComponent<Rigidbody>();
        controlCha = this.transform.GetComponent<CharacterController>();
        UIBarPlayer = GameObject.Find("MainCamera/ProgressPlayer").GetComponent<Progressbar>();
        BCPlayer = this.transform.GetComponent<BoxCollider>();
        this.transform.position = new Vector3(0f,this.transform.position.y,this.transform.position.z);
        way = "middle";

        offsetPlayerMin = this.transform.position.x - 2.5f;
        offsetPlayerMax = this.transform.position.x + 2.5f;
        /*Debug.Log(offsetPlayerMin);
        Debug.Log(offsetPlayerMax);*/

        move = "run";

        AnimPlayer = GetComponent<Animator>();

        AnimUIHit = GameObject.Find("MainCamera/ProgressPlayer/damageImage").transform.GetComponent<Animator>();
        AnimUILowHealth = GameObject.Find("MainCamera/ProgressPlayer/lowHealthImage").transform.GetComponent<Animator>();

        CC = GameObject.Find("MainCamera").GetComponent<CameraController>();
        isShield = false;

	}
	
	void Update () {
        LevelUP();
        Controller();
        Move();
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
            Debug.Log("speedGet");
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
                    Debug.Log("attack");
                AnimPlayer.SetTrigger("isAttack");
                transform.Find("UIPlayer/statusIcon").transform.GetComponent<Image>().sprite = Resources.Load("UIPlayer/attackIcon",typeof(Sprite)) as Sprite; 
                transform.Find("UIPlayer/statusIcon").transform.GetComponent<Animator>().SetTrigger("isAttack");
            }
            else if (powerAttack < obj.GetComponent<EnemyBehavior>().power)
            {
                int damageRemain = obj.GetComponent<EnemyBehavior>().power - powerAttack;
                if (powerDefence >= damageRemain)
                {
                        Debug.Log("defence");
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
                soundManagerPlayer.PlayOneShot(soundStore[0]);
                uiPlayer.amountMonsterKilled++;
                if (powerAttack < obj.GetComponent<EnemyBehavior>().power)
                {
                    powerAttack = 0;
                }
                else
                {
                    powerAttack -= obj.GetComponent<EnemyBehavior>().power;
                }
                obj.GetComponent<EnemyBehavior>().isKilled = true;
                GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
                Destroy(smoke, 4f);
                Destroy(obj.gameObject);
            }

            else if(block)
            {
                soundManagerPlayer.PlayOneShot(soundStore[1]);
                int damageRemain = obj.GetComponent<EnemyBehavior>().power - powerAttack;
                powerAttack = 0;
                powerDefence -= damageRemain;
                uiPlayer.amountMonsterKilled++;
                obj.GetComponent<EnemyBehavior>().isKilled = true;
                GameObject smoke = Instantiate(effectImpact, this.transform.position, Quaternion.identity);
                Destroy(smoke, 4f);
                Destroy(obj.gameObject);
            }
        }
    }
    #endregion

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

    #region CheckStarterStatus
    void StarterStatus()
    {
       // PlayerPrefs.SetInt("levelPlayer",LevelPlayer);

        //------LevelAttack And LevelDefence---------
        int levelAttack = PlayerPrefs.GetInt("levelAttackLevel");
        //all Attack get     "upgrade"       "levelPlayer"  "levelWeapon(attack)"
        maxPowerAttack = (levelAttack + 1)+ (LevelPlayer+1)+(attackWeapon);
        powerAttack = maxPowerAttack;
        int levelDefence = PlayerPrefs.GetInt("levelDefenceLevel");
        //all Attack get            "upgrade"               "levelPlayer"          "levelWeapon(defence)"
        maxPowerDefence = (5 + ((levelDefence - 1) * 2)) + ( 5 +(LevelPlayer-1)*2) + (defenceWeapon);
        powerDefence = maxPowerDefence;
        //Debug.Log("levelDefence : "+ levelDefence +"\n (levelDefence-1) *2 :" + (levelDefence-1)*2);

        //-------LevelMagnet LevelImmortal LevelCoin---------
        int levelMagnet = PlayerPrefs.GetInt("levelMagnetLevel");
        timeMagnet = 10 + (levelMagnet - 1)*5; 
        int levelshield = PlayerPrefs.GetInt("levelShieldLevel");
        timeShield = 10 + (levelshield - 1)*5;
        int levelImmortal = PlayerPrefs.GetInt("levelImmortalLevel");
        timeQuick = 10 + (levelImmortal - 1)*5;

    }
    #endregion

    void LevelUP()
    {
        int expPlayer = PlayerPrefs.GetInt("expPlayer");
        int maxExpPlayer = 10 * (int)(Mathf.Pow(2, PlayerPrefs.GetInt("levelPlayer") - 1)); 

        if (LevelPlayer >= 5 && expPlayer >= maxExpPlayer)
        {
            LevelPlayer = 5;
            expPlayer = maxExpPlayer;
            PlayerPrefs.SetInt("levelPlayer",LevelPlayer);
            PlayerPrefs.SetInt("expPlayer", expPlayer);
        }

        else if (expPlayer >= maxExpPlayer)
        {
            LevelPlayer++;
            PlayerPrefs.SetInt("levelPlayer",LevelPlayer);
            PlayerPrefs.SetInt("expPlayer", 0);
        }
    }

    #region StartEquip
    void equipWeapon()
    {
        equipSet = PlayerPrefs.GetInt("weaponEquiped");
        GameObject sword = Instantiate(swordType[equipSet], posEquip[1].transform.position, posEquip[1].transform.rotation);
        sword.transform.SetParent(posEquip[1].transform);
        sword.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
       
        GameObject shield = Instantiate(shieldType[equipSet], posEquip[0].transform.position, posEquip[0].transform.rotation);
        shield.transform.SetParent(posEquip[0].transform);
        shield.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }

    void CheckStatusWeaponEquip()
    {
        int weaponSetEquiped = PlayerPrefs.GetInt("weaponEquiped"); 

        switch (weaponSetEquiped)
        {
            case 0:
                attackWeapon = 1;
                defenceWeapon = 1;
                break;
            case 1:
                attackWeapon = 2;
                defenceWeapon = 1;
                break;
            case 2:
                attackWeapon = 1;
                defenceWeapon = 2;
                break;
            case 3:
                attackWeapon = 2;
                defenceWeapon = 2;
                break;
            case 4:
                attackWeapon = 3;
                defenceWeapon = 2;
                break;
            case 5:
                attackWeapon = 3;
                defenceWeapon = 3;
                break;
        }

    }
    #endregion

    void OnDestroy()
    {
        Time.timeScale = 1;
    }
    }
//PlayerPrefs.GetInt("levelPlayer");

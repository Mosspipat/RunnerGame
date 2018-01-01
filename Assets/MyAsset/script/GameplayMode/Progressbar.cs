using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {

    playerController pc;
    CameraController cc;

    public Image loadHealthbar;
    public Image loadEnergybar;

    public Text amountTreasure;
    public Text fullAmountTreasure;

    float health = 5f;
    float energy = 0f;
    float fullEnenrgy= 5f;

    bool canIncreaseEnergy;

    public static int amountTreasureInt = 0;
    int fullAmountTresureInt = 5;

    Text powerAttackText;
    Text powerDefenceText;
    int powerAttackPoint;
    int powerDefencePoint;

    public GameObject effectSpeed;

    Image imagetimeAttack;
    float timeAttackCooldown = 1;

    void Start()
    {
        loadHealthbar = GameObject.Find("ProgressHealthBar/loadHealthBar").GetComponent<Image>();
        loadEnergybar = GameObject.Find("ProgressEnergyBar/loadEnergyBar").GetComponent<Image>();

        amountTreasure =  GameObject.Find("treasureCollect/amount").GetComponent<Text>();
        fullAmountTreasure = GameObject.Find("treasureCollect/fullAmount").GetComponent<Text>();

        powerAttackText = GameObject.Find("powerStatus/attack/attackPower").GetComponent<Text>();
        powerDefenceText = GameObject.Find("powerStatus/defence/defencePower").GetComponent<Text>();

        canIncreaseEnergy = true;
        pc = GameObject.Find("player").GetComponent<playerController>();

        cc = GameObject.Find("Main Camera").transform.GetComponent<CameraController>();

        imagetimeAttack = this.transform.Find("powerStatus/attack/clockAttack/time").GetComponent<Image>();
    }

    void Update()
    {
        healthBar();
        EnergyBar();
        skillTime();
        LowHealhEffectCheck();
        TreasureText();
        PowerStatusUpdate();
        TimerAttackIncreasing();
    }

    #region DetailPlayer
    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ScoreManagerAndEvent.isDead = true;
            Application.LoadLevel("gameover");
        }
    }

    #endregion

    #region HealthAndEnergyBarUpdate
    void healthBar()
    {
        loadHealthbar.fillAmount = health/5f;
    }

    void EnergyBar()
    {
        IncreaseEnergy();
        loadEnergybar.fillAmount = energy/fullEnenrgy;
        if (energy >= 5f)
        {
            energy = 5;
        }
        if (energy <= 0f)
        {
            energy = 0;
        }
    }
    #endregion

    #region SkillUpdate
    public void skillTime()
    {
        if (Input.GetKeyDown(KeyCode.F)&&loadEnergybar.fillAmount == 1)
        {
            Debug.Log("Use Skill Timing");
            energy = 0;
            canIncreaseEnergy = false;
            
            playerController.forceSpeed = 7;
            /*Time.timeScale = 2f;*/
            Invoke("StopTimingSkill", 5f);
            cc.isSpeed = true;
            effectSpeed.active = true;                  //active particle Speed
        }
    }

    void StopTimingSkill()
    {
        playerController.forceSpeed = 5;
        /*Time.timeScale = 1f;*/
        canIncreaseEnergy = true;
        effectSpeed.active = false;
    }

    void IncreaseEnergy()
    {
        if (canIncreaseEnergy == true)
        {
            energy += 0.5f * Time.deltaTime;
        }
    }
    #endregion

    #region timeAttackIncreasing
    public void TimerAttackIncreasing()
    {
        timeAttackCooldown -= 0.1f *Time.deltaTime ;
        imagetimeAttack.fillAmount = timeAttackCooldown;
        //if powerAttack is not full 
        if (imagetimeAttack.fillAmount <= 0 && playerController.powerAttack < playerController.maxPowerAttack)
        {
            playerController.powerAttack++;
            timeAttackCooldown = 1;
        }
        //if powerAttack is full ,cooldown will not work
        else if (playerController.powerAttack >= playerController.maxPowerAttack)
        {
            timeAttackCooldown = 1.01f;
        }
        else if (playerController.EndStage == true)
        {
            timeAttackCooldown = 1.01f;
        }
    }

    #endregion

    #region LowHealhEffectCheck
    void LowHealhEffectCheck()
    {
        if (health <= 1)
        {
            /*cc.lowHealth = true;*/
            pc.StartLowHealthAnimation();
        }
        else
        {
            pc.StopLowHealthAnimation();
        }
    }
    #endregion

    #region CollectionTreasureMapUpdate
    void TreasureText()
    {
        amountTreasure.text = " Collected " + amountTreasureInt.ToString();
        fullAmountTreasure.text = "/ " +fullAmountTresureInt.ToString();

        if (amountTreasureInt >= fullAmountTresureInt)
        {
            //no more over than full Collected
            amountTreasureInt = fullAmountTresureInt;
            GameObject.Find("treasureCollect").GetComponent<Image>().sprite = Resources.Load("UIPlayer/treasureChest", typeof(Sprite)) as Sprite;;

            tileManager.questCollect= true; 
        }
    }
    #endregion

    #region PowerStatusUpdate
    void PowerStatusUpdate()
    {
        powerAttackText.text = (playerController.powerAttack).ToString(); 
        powerDefenceText.text = (playerController.powerDefence).ToString(); 
    }
    #endregion


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour {

    public Image loadHealthbar;
    public Image loadEnergybar;
    playerController pc;

    float health = 5f;
    float energy = 0f;
    float fullEnenrgy= 5f;

    bool canIncreaseEnergy;

    CameraController cc;

    public GameObject effectSpeed;

    void Start()
    {
        loadHealthbar = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        loadEnergybar = this.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        canIncreaseEnergy = true;
        pc = GameObject.Find("player").GetComponent<playerController>();

        cc = GameObject.Find("Main Camera").transform.GetComponent<CameraController>();
    }

    void Update()
    {
        healthBar();
        EnergyBar();
        skillTime();
        LowHealhEffectCheck();
    }

    #region DetailPlayer
    public void GetDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            pc.isDead = true;
            Application.LoadLevel("gameover");
        }
    }

    public void skillTime()
    {
        if (Input.GetKeyDown(KeyCode.W)&&loadEnergybar.fillAmount == 1)
        {
            Debug.Log("Use Skill Timing");
            energy = 0;
            canIncreaseEnergy = false;
            Time.timeScale = 2f;
            Invoke("StopTimingSkill", 5f);

            cc.isSpeed = true;
            effectSpeed.active = true;                  //active particle Speed
        }
    }
    #endregion

    #region BarUpdate
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

    #region Skill
    void StopTimingSkill()
    {
        Time.timeScale = 1f;
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



}

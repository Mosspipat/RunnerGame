using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;
using UnityEngine.UI;
public class BossBehavior : MonoBehaviour {

    public Animator AnimBoss;
    public GameObject headBoss;
    Transform bodyBoss;

    public static bool isLookatBoss = false;
    public static bool isBossApprea = false;

    public Image healthCanvas;
    float currentHealth = 100;
    float fullHealth = 100;
    bool isLowHealth = false;
    public static int energy = 10;

    void Start () 
    {
        AnimBoss = this.transform.Find("boss").GetComponent<Animator>();
        AnimBoss.SetTrigger("isMove");
        Invoke("AttackActionType", 5f);
        isBossApprea = true;
        isLookatBoss = true;
        healthCanvas = this.transform.Find("healthBossCanvas/healthBar/health").GetComponent<Image>();
        bodyBoss = this.transform.Find("boss/body").transform;
       this.transform.position = new Vector3(-0.71f, GameObject.Find("player").transform.position.y + 5f, GameObject.Find("player").transform.position.z - 15f);
    }
    
    void Update () {

        healthCanvas.fillAmount = currentHealth / fullHealth;
        HealthControll();
        TiredAction();
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

    #region BossAppreaFirstPosition
    void startAppreaPositionBoss()
    {
        if (isLookatBoss == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(-0.71f,GameObject.Find("player").transform.position.y+5f,GameObject.Find("player").transform.position.z+15f),0.1f );
        }
        else if(AnimationEventBoss.isAttacked == false)         // if true hit let boss rotate with "isAttacked" animation 
        {
            this.transform.position = new Vector3(-0.71f,GameObject.Find("player").transform.position.y+5f,GameObject.Find("player").transform.position.z+15f);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.Euler(0,180f,0), 0.1f);
        
        }
    }
    #endregion

    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "player")
        {
            Debug.Log("attack player");
        }
        else if (obj.name == "fireBall")
        {
            Debug.Log("boss was hit");
            currentHealth -= 1;
        }
    }

    #region AttackType
    void HealthControll()
    {
        if (currentHealth <= 50 && isLowHealth == false)
        {
            AnimBoss.SetTrigger("isAttacked");
            isLowHealth = true;
        }
        else if (currentHealth <= 0)
        {
            Debug.Log("boss die!!");
            AnimBoss.SetTrigger("isDead");
            currentHealth = 0;
        }
    }
    public void AttackActionType()
    {
            int typeAttack = Random.Range(1,4);
            switch (typeAttack)
            {
                case 1:
                    AnimBoss.SetTrigger("isAttack1");
                    break;
                case 2:
                    AnimBoss.SetTrigger("isAttack2");
                    break;
                case 3:
                    AnimBoss.SetTrigger("isAttack3");
                    break;
            }
    }
    void TiredAction()
    {
        if (energy <= 0)
        {
            AnimBoss.SetTrigger("isTired");
            energy = 10;
        }
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour {

    GameObject player;
    public GameObject effectSpeed;

    float offset = 15f;
    float enemyCheckPlayerPoint;
    bool shoot;

    Animator AnimEnemy;

    Text powerText;
    public int power;

    void Start()
    {
        player = GameObject.Find("player");
        enemyCheckPlayerPoint = this.transform.position.z - offset;
        powerText = transform.Find("power/powerAttack").GetComponent<Text>();
        powerText.text = power.ToString();

        AnimEnemy = this.transform.Find(this.name + "Rig").GetComponent<Animator>();
    }

	void Update () {
        if (player.transform.position.z > enemyCheckPlayerPoint && this.gameObject.name == "rabbit")
        {
            BehaviorRabbit();
        }
        else if (player.transform.position.z > enemyCheckPlayerPoint&&this.gameObject.name =="slime")
        {
            BehaviorSlime();
        }
        else if (player.transform.position.z > enemyCheckPlayerPoint&&this.gameObject.name =="bat")
        {
            BehaviorBat();
        }
        else if (player.transform.position.z > enemyCheckPlayerPoint&&this.gameObject.name =="ghost")
        {
            BehaviorGhost();
        }
        else if (player.transform.position.z > enemyCheckPlayerPoint&&this.gameObject.name =="fireMonster")
        {
            BehaviorFireMonster();
        }
        else if (player.transform.position.z > enemyCheckPlayerPoint&&this.gameObject.name =="skeleton")
        {
            BehaviorSkeleton();
        }
        DestroyitSelf();
    }

    #region Monster Bedavior
    void BehaviorRabbit()
    {
        FindTarget(player); 
    }

    void BehaviorSlime()
    {
        this.transform.Find("slimeRig").GetComponent<Animator>().SetTrigger("isShoot");
        FindTarget(player);                                                         //spawn Bullet
    }
    void BehaviorBat()
    {
        this.transform.Find("batRig").GetComponent<Animator>().SetTrigger("isFly");
        this.transform.Translate(new Vector3(0, 0, -10f * Time.deltaTime));           //Move forward Only
        effectSpeed.active = true;
    }
    void BehaviorGhost()
    {
        this.transform.Find("ghostRig").GetComponent<Animator>().SetTrigger("isShoot");
        FindTarget(player); 
    }
    void BehaviorFireMonster()
    {
        this.transform.Find("fireMonsterRig").GetComponent<Animator>().SetTrigger("isShoot");
        this.transform.Translate(new Vector3(0, 0, 7f * Time.deltaTime));
        FindTarget(player);

    }
    void BehaviorSkeleton()
    {
        this.transform.Find("skeletonRig").GetComponent<Animator>().SetTrigger("isWalk");
        this.transform.Translate(new Vector3(0, 0, 7f * Time.deltaTime));           //Move forward Only
        FindTarget(player);
    }
    #endregion
    
    void FindTarget(GameObject player)
    {
        this.transform.LookAt(player.transform.position);
    }


    void DestroyitSelf()
    {
        if (this.transform.position.z < player.transform.position.z - offset)
        {
            Destroy(this.gameObject);
            Debug.Log("delete Enemy");
        }
    }
    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "player")
        {
            AnimEnemy.SetTrigger("isAttack");
            this.transform.Find(this.name + "Rig").GetComponent<Animator>().SetTrigger("isAttack");
            this.GetComponent<EnemyBehavior>().enabled = false;
        }
    }

}
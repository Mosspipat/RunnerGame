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

    Text powerText;
    public int power;

    void Start()
    {
        player = GameObject.Find("player");
        enemyCheckPlayerPoint = this.transform.position.z - offset;
        powerText = transform.Find("power/powerAttack").GetComponent<Text>();
        powerText.text = power.ToString();
    }

	void Update () {
        if (player.transform.position.z > enemyCheckPlayerPoint && this.gameObject.name == "monsterOne")
        {
            BehaviorTwo();
        }
        else if (player.transform.position.z > enemyCheckPlayerPoint&&this.gameObject.name =="monsterShoot")
        {
            BehaviorThree();
        }
        DestroyitSelf();
    }

    void BehaviorOne()
    {
        FindTarget(player);
        this.transform.Translate(new Vector3(0, 0, 1f * Time.deltaTime));           //Transform to player;
        powerText.text = "5"; 
    }

    void BehaviorTwo()
    {
        this.transform.Find("BatRig").GetComponent<Animator>().SetTrigger("isAttack");
        this.transform.Translate(new Vector3(0, 0, -10f * Time.deltaTime));           //Move forward Only
        effectSpeed.active = true;
    }

    void BehaviorThree()
    {
        this.transform.Find("slimeRig").GetComponent<Animator>().SetTrigger("isAttack");
        FindTarget(player);                                                         //spawn Bullet
    }
    
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
            this.GetComponent<EnemyBehavior>().enabled = false;
        }
    }
}
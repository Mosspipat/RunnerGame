using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    GameObject player;
    public GameObject bullet;
    public Transform spawnBulletPoint;

    float offset = 20f;
    float enemyCheckPlayerPoint;
    bool shoot;

    void Start()
    {
        player = GameObject.Find("player");
        enemyCheckPlayerPoint = this.transform.position.z - offset;
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
    }

    void BehaviorTwo()
    {
        this.transform.Translate(new Vector3(0, 0, 10f * Time.deltaTime));           //Move forward Only
    }

    void BehaviorThree()
    {
        FindTarget(player);                                                         //spawn Bullet
        if (shoot == false)
        {
            shoot = true;
            Invoke("ShootPlayer",1f);
        }
    }
    
    void FindTarget(GameObject player)
    {
        this.transform.LookAt(player.transform.position);
    }

    void ShootPlayer()
    {
        if(shoot == true)
        {
        GameObject bulletEnemy = Instantiate(bullet,spawnBulletPoint.position,spawnBulletPoint.rotation);
        bulletEnemy.name = "bullet";
        shoot = false;
        }
    }

    void DestroyitSelf()
    {
        if (this.transform.position.z < player.transform.position.z - offset)
        {
            Destroy(this.gameObject);
            Debug.Log("delete Enemy");
        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOrEnemy : MonoBehaviour {

    public GameObject Coin;
    public GameObject Enemy;
    public Transform spawnPointer;
    GameObject coinObj;

    tileManager tileManage;

	void Start () {
        tileManage = GameObject.Find("tileManager").GetComponent<tileManager>();    

        int randomSpawn = Random.Range(1, 3);
        if (randomSpawn == 1)
        {
            SpawnCoin();
        }
        else if (randomSpawn == 2)
        {
            SpawnMonsterTypeOne();
        }
    }


    void SpawnCoin()
    {
        foreach (Transform pointer in spawnPointer)
        {
            coinObj = Instantiate(Coin, pointer.transform.position,Coin.transform.rotation) as GameObject;
            coinObj.name = "coin";
        }
    }

    void SpawnMonsterTypeOne()
    {
        foreach (Transform pointer in spawnPointer)
        {
            coinObj = Instantiate(Enemy, pointer.transform.position,Enemy.transform.rotation) as GameObject;
            coinObj.name = "monsterOne";
        } 
    }


}

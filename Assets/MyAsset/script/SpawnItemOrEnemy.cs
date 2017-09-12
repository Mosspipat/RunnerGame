using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOrEnemy : MonoBehaviour {

    public GameObject Coin;
    public GameObject Enemy;
    public Transform spawnPointer;
    GameObject coinObj;
    GameObject enemyObj;

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
            int randomPointerSpawn = Random.Range(0, 9);
            SpawnMonsterTypeOne(randomPointerSpawn);
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

    void SpawnMonsterTypeOne(int randomPointer)
    {
        
        enemyObj = Instantiate(Enemy,spawnPointer.GetChild(randomPointer).position,Enemy.transform.rotation) as GameObject;
        enemyObj.name = "monsterOne";
    }


}

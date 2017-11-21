using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOrEnemy : MonoBehaviour {

    public GameObject Coin;
    public GameObject Enemy;
    public GameObject EnemyShoot;
    public Transform spawnPointer;
    GameObject coinObj;
    GameObject enemyObj;

    tileManager tileManage;

	void Start () {
        tileManage = GameObject.Find("tileManager").GetComponent<tileManager>();    

        int randomSpawn = Random.Range(1, 4);
        if (randomSpawn == 1)
        {
            SpawnCoin();
        }
        else if (randomSpawn == 2)
        {
            int randomPointerSpawn = Random.Range(0, 9);
            SpawnMonsterTypeOne(randomPointerSpawn);
        }
        else if (randomSpawn == 3)
        {
            int randomPointerSpawn = Random.Range(0, 9);
            SpawnMonsterTypeTwo(randomPointerSpawn);
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
        enemyObj = Instantiate(Enemy,spawnPointer.GetChild(randomPointer).position+Vector3.up*0.5f,spawnPointer.GetChild(randomPointer).transform.rotation) as GameObject;
        enemyObj.name = "monsterOne";
    }

    void SpawnMonsterTypeTwo(int randomPointer)
    {
        enemyObj = Instantiate(EnemyShoot,spawnPointer.GetChild(randomPointer).position,spawnPointer.GetChild(randomPointer).transform.rotation) as GameObject;
        enemyObj.name = "monsterShoot";
    }

}

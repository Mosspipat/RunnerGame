using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOrEnemy : MonoBehaviour {

    public GameObject Coin;
    public GameObject Enemy;
    public GameObject EnemyShoot;

    public GameObject ItemChestPiece;
    public GameObject ItemHealth;

    public Transform spawnPointer;

    GameObject coinObj;
    GameObject enemyObj;

    tileManager tileManage;

	void Start () {
        //when start Find tileManager and get TileManagerScript
        tileManage = GameObject.Find("tileManager").GetComponent<tileManager>();    

        //Random Case "Coin" or "MonterOne" or "MonsterTwo" Spawn in platform
        int randomSpawn = Random.Range(1, 5);
        switch (randomSpawn)
        {
            //Coin
            case 1:
                SpawnCoin();
            break;
            //Monster One
            case 2:
                int randomPointerSpawnOne = Random.Range(0, 9);
                SpawnMonsterTypeOne(randomPointerSpawnOne);
                break;
            //Monster Two
            case 3:
                int randomPointerSpawnTwo = Random.Range(0, 9);
                SpawnMonsterTypeTwo(randomPointerSpawnTwo);
                break;
            case 4:
                int randomPointerSpawnMapTreasure = Random.Range(0, 9);
                SpawnItem(randomPointerSpawnMapTreasure);
                break;
        }
    }

    #region Case Spawn Coin/Monter1/Monster2
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
    void SpawnItem(int randomPointer)
    {
        enemyObj = Instantiate(ItemChestPiece,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemChestPiece.transform.rotation) as GameObject;
        enemyObj.name = "mapTreasure";
    }
    #endregion
}

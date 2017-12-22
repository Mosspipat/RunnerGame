using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOrEnemy : MonoBehaviour {

    public GameObject Coin;
    public GameObject Enemy;
    public GameObject EnemyShoot;

    public GameObject ItemChestPiece;
    public GameObject ItemAttack;
    public GameObject ItemDefence;

    public Transform spawnPointer;

    GameObject coinObj;
    GameObject enemyObj;
    GameObject itemSpawn;

    int randomSpawn;

    tileManager tileManage;

	void Start () {
        //when start Find tileManager and get TileManagerScript
        tileManage = GameObject.Find("tileManager").GetComponent<tileManager>();    

        //Random Case "Coin" or "MonterOne" or "MonsterTwo" Spawn in platform

        if(tileManager.amountSpawnedPlatform % 2 == 0)
        {
            randomSpawn = Random.Range(2, 4);    
        }

        else
        {
            randomSpawn = Random.Range(1, 7);
        }
            


        switch (randomSpawn)
        {
            // Spawn Coin//
            case 1:
                SpawnCoin();
            break;
            //Monster Spawn//
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
            //Item Spawn//
            //Map
            case 4:
                int randomPointerSpawnMapTreasure = Random.Range(0, 9);
                SpawnItem(randomPointerSpawnMapTreasure);
                break;
            //Shield
            case 5:
                int randomPointerSpawnItemAttack = Random.Range(0, 9);
                SpawnAttackItem(randomPointerSpawnItemAttack);
                break;
            case 6:
                int randomPointerSpawnDefenceAttack = Random.Range(0, 9);
                SpawnAttackItem(randomPointerSpawnDefenceAttack);
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

    //Spawn Item
    void SpawnAttackItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemAttack,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemChestPiece.transform.rotation) as GameObject;
        itemSpawn.name = "ItemAttack";
    }
    void SpawnDeffenceItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemDefence,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemChestPiece.transform.rotation) as GameObject;
        itemSpawn.name = "ItemDefence";
    }
    #endregion
}

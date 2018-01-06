using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOrEnemyBlackForest : MonoBehaviour {

    public GameObject Coin;

    public GameObject slime;
    public GameObject ghost;
    public GameObject skeleton;

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
            randomSpawn = Random.Range(1, 4);    
        }

        /*else
        {
            randomSpawn = Random.Range(4, 6);
        }*/

        switch (randomSpawn)
        {
            //Monster Spawn//
            //Monster One
            case 1:
                SpawnMonsterSlime();
                break;
                //Monster Two
            case 2:
                SpawnMonsterGhost();
                break;
            case 3:
                SpawnMonsterSkeleton();
                break;
                //Item Spawn//
                //Map
            case 4:
                int randomPointerSpawnMapTreasure = Random.Range(0, 9);
                SpawnItem(randomPointerSpawnMapTreasure);
                break;
                //attack&defence Spawn//
            case 5:
                int randomPointerSpawnItemAttack = Random.Range(0, 9);
                SpawnAttackItem(randomPointerSpawnItemAttack);
                break;
            case 6:
                int randomPointerSpawnDefenceAttack = Random.Range(0, 9);
                SpawnAttackItem(randomPointerSpawnDefenceAttack);
                break;
                //coin Spawn//
            case 7:
                SpawnCoin();
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
    //Sapwn Level monster//
    void SpawnMonsterSlime()
    {
        int randomPointerSpawn = Random.Range(0, 9);
        enemyObj = Instantiate(slime,spawnPointer.GetChild(randomPointerSpawn).position,spawnPointer.GetChild(randomPointerSpawn).transform.rotation) as GameObject;
        enemyObj.name = "slime";
    }
    void SpawnMonsterGhost()
    {
        int randomPointerSpawn = Random.Range(0, 9);
        enemyObj = Instantiate(ghost,spawnPointer.GetChild(randomPointerSpawn).position,spawnPointer.GetChild(randomPointerSpawn).transform.rotation) as GameObject;
        enemyObj.name = "ghost";
    }
    void SpawnMonsterSkeleton()
    {
        int randomPointerSpawn = Random.Range(0, 9);
        enemyObj = Instantiate(skeleton,spawnPointer.GetChild(randomPointerSpawn).position- Vector3.up*0.5f,spawnPointer.GetChild(randomPointerSpawn).transform.rotation) as GameObject;
        enemyObj.name = "skeleton";
    }

    //Spawn Item //
    void SpawnItem(int randomPointer)
    {
        enemyObj = Instantiate(ItemChestPiece,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemChestPiece.transform.rotation) as GameObject;
        enemyObj.name = "mapTreasure";
    }
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

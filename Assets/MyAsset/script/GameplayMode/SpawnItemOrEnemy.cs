using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOrEnemy : MonoBehaviour {

    public GameObject Coin;

    public int stage{ get; set;}

    public GameObject rabbit;
    public GameObject bat;
    public GameObject slime;
    public GameObject ghost;
    public GameObject fireMonster;
    public GameObject skeleton;

    public GameObject ItemChestPiece;
    public GameObject ItemAttack;
    public GameObject ItemDefence;

    public GameObject ItemShield;
    public GameObject ItemSpeed;
    public GameObject ItemMagnet;
    public GameObject ItemHealth;

    public Transform spawnPointer;

    GameObject coinObj;
    GameObject enemyObj;
    GameObject itemSpawn;

    int randomSpawn;

    tileManager tileManage;

	void Start () {
        //get "Stage Selected"
        stage = GameObject.Find("SceneSelectManager").GetComponent<SelectionScene>().stageSeleted;
        //when start Find tileManager and get TileManagerScript
        tileManage = GameObject.Find("tileManager").GetComponent<tileManager>();    

        //Random Case "Coin" or "MonterOne" or "MonsterTwo" Spawn in platform

        if (tileManager.amountSpawnedPlatform % 2 == 0 && stage == 1)
        {
            randomSpawn = Random.Range(1, 3);    
        }
        else if (tileManager.amountSpawnedPlatform % 2 == 0 && stage == 2)
        {
            randomSpawn = Random.Range(1, 4);   
        }
        else if (tileManager.amountSpawnedPlatform % 2 == 0 && stage == 3)
        {
            randomSpawn = Random.Range(3, 5);   
        }
        else if (tileManager.amountSpawnedPlatform % 2 == 0 && stage == 4)
        {
            int randomHighMonster = Random.Range(1, 3);
            switch (randomHighMonster)
            {
                case 1:
                    randomSpawn = Random.Range(3, 5);
                    break;
                case 2:
                    randomSpawn = 6;
                    break;
            }
        }
        else if (tileManager.amountSpawnedPlatform % 2 == 0 && stage == 5)
        {
            int randomHighMonster = Random.Range(1, 3);
            switch (randomHighMonster)
            {
                case 1:
                    randomSpawn = 3;
                    break;
                case 2:
                    randomSpawn = 5;
                    break;
            }
        }
        else if (tileManager.amountSpawnedPlatform % 2 == 0 && stage == 6)
        {
            int randomHighMonster = Random.Range(1, 4);
            switch (randomHighMonster)
            {
                case 1:
                    randomSpawn = 3;
                    break;
                case 2:
                    randomSpawn = 5;
                    break;
                case 3:
                    randomSpawn = 6;
                    break;
            }
        }
        else
        {
            randomSpawn = Random.Range(10, 15); 
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
                SpawnMonsterRabbit();
                break;
            //Monster Two
            case 2:
                SpawnMonsterBat();
                break;
            case 3:
                SpawnMonsterSlime();
                break;
            case 4:
                SpawnMonsterGhost();
                break;
            case 5:
                SpawnMonsterFireMonster();
                break;
            case 6:
                SpawnMonsterSkeleton();
                break;
            //Item Spawn//
            //Map
            case 7:
                int randomPointerSpawnMapTreasure = Random.Range(0, 9);
                SpawnItem(randomPointerSpawnMapTreasure);
                break;
            //attack&defence Spawn//
            case 8:
                int randomPointerSpawnItemAttack = Random.Range(0, 9);
                SpawnAttackItem(randomPointerSpawnItemAttack);
                break;
            case 9:
                int randomPointerSpawnDefenceAttack = Random.Range(0, 9);
                SpawnDeffenceItem(randomPointerSpawnDefenceAttack);
                break;
            //coin Spawn//
            case 10:
                SpawnCoin();
                break;
            case 11:
                int randomPointerSpawnShield = Random.Range(0, 9);
                SpawnShieldItem(randomPointerSpawnShield);
                break;
            case 12:
                int randomPointerSpawnMagnet = Random.Range(0, 9);
                SpawnMagnetItem(randomPointerSpawnMagnet);
                break;
            case 13:
                int randomPointerSpawnSpeed = Random.Range(0, 9);
                SpawnSpeedItem(randomPointerSpawnSpeed);
                break;
            case 14:
                int randomPointerSpawnHealth = Random.Range(0, 9);
                SpawnHealthItem(randomPointerSpawnHealth);
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
    void SpawnMonsterRabbit()
    {
        int randomPointerSpawn = Random.Range(0, 9);
        enemyObj = Instantiate(rabbit,spawnPointer.GetChild(randomPointerSpawn).position-Vector3.up*0.4f,spawnPointer.GetChild(randomPointerSpawn).transform.rotation) as GameObject;
        enemyObj.name = "rabbit";
    }
    void SpawnMonsterBat()
    {
        int randomPointerSpawn = Random.Range(0, 9);
        enemyObj = Instantiate(bat,spawnPointer.GetChild(randomPointerSpawn).position+Vector3.up*0.5f,spawnPointer.GetChild(randomPointerSpawn).transform.rotation) as GameObject;
        enemyObj.name = "bat";
    }
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
    void SpawnMonsterFireMonster()
    {
        int randomPointerSpawn = Random.Range(0, 9);
        enemyObj = Instantiate(fireMonster,spawnPointer.GetChild(randomPointerSpawn).position,spawnPointer.GetChild(randomPointerSpawn).transform.rotation) as GameObject;
        enemyObj.name = "fireMonster";
    }
    void SpawnMonsterSkeleton()
    {
        int randomPointerSpawn = Random.Range(0, 9);
        enemyObj = Instantiate(skeleton,spawnPointer.GetChild(randomPointerSpawn).position- Vector3.up*0.5f,spawnPointer.GetChild(randomPointerSpawn).transform.rotation) as GameObject;
        enemyObj.name = "skeleton";
    }

    //----------Spawn Item----------- //
    void SpawnItem(int randomPointer)
    {
        enemyObj = Instantiate(ItemChestPiece,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemChestPiece.transform.rotation) as GameObject;
        enemyObj.name = "mapTreasure";
    }
    //Item Power
    void SpawnAttackItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemAttack,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemAttack.transform.rotation) as GameObject;
        itemSpawn.name = "itemAttack";
    }
    void SpawnDeffenceItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemDefence,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemDefence.transform.rotation) as GameObject;
        itemSpawn.name = "itemDefence";
    }
    // Items Support
    void SpawnShieldItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemShield,spawnPointer.GetChild(randomPointer).position + Vector3.up * 1f,ItemShield.transform.rotation) as GameObject;
        itemSpawn.name = "bariaItem";
    }
    void SpawnSpeedItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemSpeed,spawnPointer.GetChild(randomPointer).position + Vector3.up * 5f,ItemSpeed.transform.rotation) as GameObject;
        itemSpawn.transform.GetChild(0).name = "speedItem";
        itemSpawn.name = "speedItem";
    }
    void SpawnMagnetItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemMagnet,spawnPointer.GetChild(randomPointer).position + Vector3.up * 2f,ItemSpeed.transform.rotation) as GameObject;
        itemSpawn.transform.GetChild(0).name = "magnetItem";
        itemSpawn.name = "magnetItem";
    }
    void SpawnHealthItem(int randomPointer)
    {
        itemSpawn = Instantiate(ItemHealth,spawnPointer.GetChild(randomPointer).position + Vector3.up * 2f,ItemHealth.transform.rotation) as GameObject;
        itemSpawn.transform.GetChild(0).name = "posionItem";
        itemSpawn.name = "posionItem";
    }
    #endregion
}

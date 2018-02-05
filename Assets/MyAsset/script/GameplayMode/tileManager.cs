using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour {

    public static bool isGreenField;

    public GameObject[] platform;
    public Transform starterplatform;

    public GameObject[] trap;
    public GameObject[] trapTwo;

    float spawnPlatformPoint = 8.696283f;                       // point for Spawn first platform  
    float sizePlatform = 8.696283f;


    Transform playerPos;
    float arriveZone = 40f;                                 //set more if want to spawn more platform
    List<GameObject> allPlatformGame;

    public GameObject boss;

    public static bool dungeonStage = false;
    public static int amountDungeonCanSpawn;

    public static bool bossStage = false;

    public static bool questCollect = false;

    public static bool questDistance = false;

    bool EndStage = false;

    GameObject starterTerrian;
    public List<GameObject> terrainType = new List<GameObject>();
    public Transform starterTerrianPoint;
    float PosTerrianPlayerFirst= 0;
    float PosTerrianPlayerSecond = 200;
    float nextMoveTerrianZ = 400f;


    public static int amountSpawnedPlatform; 

    public List<GameObject> typePlatformObstacleGreen = new List<GameObject>(); //1-2
    public List<GameObject> typePlatformDungeonGreen = new List<GameObject>();

    public List<GameObject> typePlatformObstacleBlack = new List<GameObject>();//3-4
    public List<GameObject> typePlatformDungeonBlack = new List<GameObject>();

    public List<GameObject> typePlatformObstacleRed = new List<GameObject>();//5-6
    public List<GameObject> typePlatformDungeonRed = new List<GameObject>();

    public List<GameObject> typeSpawnGreen = new List<GameObject>();//1-2
    public List<GameObject> typeSpawnBlack = new List<GameObject>();//3-4
    public List<GameObject> typeSpawnRed = new List<GameObject>();//5-6

    public List<GameObject> typePlatformCastle = new List<GameObject>();//1-6
    public List<GameObject> typePlatformOrigin = new List<GameObject>();//1-6
    GameObject starterPlatformGameObj;
    public int stage;

	void Start () {                                                         //Spawn StarterPlatform when start Game
        startTerrian();
        amountSpawnedPlatform = 0;

        //make StarterPlatform
        SpawnStarterPlatform();

        if (this.isActiveAndEnabled == true)
        {
            isGreenField = true;
        }
        playerPos = GameObject.Find("player").transform;
        allPlatformGame = new List<GameObject>();

        for (int i = 0; i < 6; i++)
        {
            if (i <= 2)
            {           
                Spawnplatform(0);                                           
            }
            else                                                            //all platform show in game;
            {
                Spawnplatform(1);                           
            }
            //Debug.Log("start platform");
        }
        ResetStatusTileManager();
	}
	
	void Update () {
        MoveTerrianFollowPlayer();
        DistanceSpawnPlatform();
	}

    #region Platform from distance
    void DistanceSpawnPlatform()
    {
        if (playerPos.position.z + arriveZone >= spawnPlatformPoint && dungeonStage == false && bossStage == false && questCollect == false && questDistance == false) //allow front point player Check to The last edge platform
        {
            Debug.Log("originSpawn");
            Spawnplatform(1);           // spawn normal platform
            DeleteOldplatform();        // delete (Old platform)
        }
        //Trigger Spawn Dungeon Platform
        else if (playerPos.position.z + arriveZone >= spawnPlatformPoint && dungeonStage == true &&questDistance == false) //allow front point player Check to The last edge platform
        {
            Debug.Log("dungeonSpawn");
            Spawnplatform(2);           // spawn dungeon platform
            DeleteOldplatform();        // delete (Old platform)
        }
        //Trigger Spawn Boss Platform
        else if (playerPos.position.z + arriveZone >= spawnPlatformPoint && dungeonStage == false && bossStage == true) //allow front point player Check to The last edge platform
        {
            Spawnplatform(0);           // clone (empty platform)
            DeleteOldplatform();        // delete (Old platform)
            if (BossBehavior.isBossApprea == false)
            {
                GameObject bossGameplay = Instantiate(boss);
                bossGameplay.name = "Boss";
            }
        }
        //Trigger Spawn Collect Platform
        #region QuestCollect
        else if (playerPos.position.z + arriveZone >= spawnPlatformPoint && dungeonStage == false && bossStage == false && questCollect == true && EndStage == false) //allow front point player Check to The last edge platform
        {
            Spawnplatform(0);
            Spawnplatform(0);
            Spawnplatform(3);           // clone (empty platform)
            DeleteOldplatform();        // delete (Old platform)
            EndStage = true;
        }
        #endregion

        //Trigger Spawn Castle Platform
        #region QuestDistance
        else if (playerPos.position.z + arriveZone >= spawnPlatformPoint && dungeonStage == false && bossStage == false && questDistance == true && EndStage == false) //allow front point player Check to The last edge platform
        {
            Spawnplatform(0);
            Spawnplatform(0);
            Spawnplatform(3);
            DeleteOldplatform();        // delete (Old platform)
            EndStage = true;
        }
        #endregion
    }
    #endregion
        //Distance Event
    void SpawnStarterPlatform()
    {
        switch (stage)
        {
        case 1: case 2:
                Instantiate(typePlatformOrigin[0],starterplatform.transform.position,starterplatform.transform.rotation);
        break;
        case 3: case 4:
                Instantiate(typePlatformOrigin[1],starterplatform.transform.position,starterplatform.transform.rotation);
        break;
        case 5: case 6:
                Instantiate(typePlatformOrigin[2],starterplatform.transform.position,starterplatform.transform.rotation);
        break;
        }
    }


    #region  Origin / Obstacle / Dungeon TypePlatform
    void Spawnplatform(int typePlatform)
    {
        amountSpawnedPlatform ++; //this length is distance.z platform

        #region originPlatform
        if (typePlatform == 0 && (stage == 1||stage == 2))                       
        {
            GameObject originPlatform = Instantiate(typePlatformOrigin[0], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                         //Starter Platform
                spawnPlatformPoint),                                                                            //Continue with z pos
                starterplatform.rotation) as GameObject;
            originPlatform.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(originPlatform);
        }
        else if (typePlatform == 0 && (stage == 3 || stage == 4))                       
        {
            GameObject originPlatform = Instantiate(typePlatformOrigin[1], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                         //Starter Platform
                spawnPlatformPoint),                                                                            //Continue with z pos
                starterplatform.rotation) as GameObject;
            originPlatform.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(originPlatform);
        }
        else if (typePlatform == 0 && (stage == 5 || stage == 6))                       
        {
            GameObject originPlatform = Instantiate(typePlatformOrigin[2], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                         //Starter Platform
                spawnPlatformPoint),                                                                            //Continue with z pos
                starterplatform.rotation) as GameObject;
            originPlatform.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(originPlatform);
        }
        #endregion

        #region obstaclePlatform
        else if( typePlatform == 1 && (stage == 1||stage == 2))
        {
            int randomTypeSpawnOrOrigin = Random.Range(1,3);
            RandomPlatformObstacleOrSpawnGreenField(randomTypeSpawnOrOrigin);
        }

        else if(typePlatform == 1 && (stage == 3 || stage == 4))
        {
            int randomTypeSpawnOrOrigin = Random.Range(1,3);
            RandomPlatformObstacleOrSpawnBlackForest(randomTypeSpawnOrOrigin);
        }
        else if(typePlatform == 1 && (stage == 5 || stage == 6))
        {
            int randomTypeSpawnOrOrigin = Random.Range(1,3);
            RandomPlatformObstacleOrSpawnRedVolcano(randomTypeSpawnOrOrigin);
        }
        #endregion
        #region dungeonPlatform
        else if( typePlatform == 2 && (stage == 1||stage == 2))
        {
            GameObject dungeonPlatform = Instantiate(typePlatformDungeonGreen[0], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                         
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            dungeonPlatform.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(dungeonPlatform);

            //Check if Amount of dungeon stage is zero  make stage to "normal stage"
            amountDungeonCanSpawn--;
            if (amountDungeonCanSpawn <= 0)
            {
                dungeonStage = false;
            }
        }

        else if( typePlatform == 2 && (stage == 3 || stage == 4))
        {
            int randomDungeon = Random.Range(0,1);  //for new platform "future asset"
            GameObject dungeonPlatform = Instantiate(typePlatformDungeonBlack[randomDungeon], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                         
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            dungeonPlatform.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(dungeonPlatform);

            //Check if Amount of dungeon stage is zero  make stage to "normal stage"
            amountDungeonCanSpawn--;
            if (amountDungeonCanSpawn <= 0)
            {
                dungeonStage = false;
            }
        }

        else if( typePlatform == 2 && (stage == 5 || stage == 6))
        {
            GameObject dungeonPlatform = Instantiate(typePlatformDungeonRed[0], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                         
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            dungeonPlatform.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(dungeonPlatform);

            //Check if Amount of dungeon stage is zero  make stage to "normal stage"
            amountDungeonCanSpawn--;
            if (amountDungeonCanSpawn <= 0)
            {
                dungeonStage = false;
            }
        }
        #endregion
        #region specialPlatform
        // special platform Secret Chest
        else if( typePlatform == 3&&(stage == 1 || stage == 2))
        {
            GameObject specialFloor = Instantiate(typePlatformCastle[0], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                          //Random Trap platform
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            specialFloor.name = "castlePlatform";
            specialFloor.transform.SetParent(this.transform);
            /*spawnPlatformPoint += sizePlatform;*/                 //was finish don't use
            allPlatformGame.Add(specialFloor);
        }

        else if( typePlatform == 3&&(stage == 3 || stage == 4))
        {
            GameObject specialFloor = Instantiate(typePlatformCastle[1], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                          //Random Trap platform
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            specialFloor.name = "castlePlatform";
            specialFloor.transform.SetParent(this.transform);
            /*spawnPlatformPoint += sizePlatform;*/                 //was finish don't use
            allPlatformGame.Add(specialFloor);
        }

        else if( typePlatform == 3&&(stage == 5 || stage == 6))
        {
            GameObject specialFloor = Instantiate(typePlatformCastle[2], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                          //Random Trap platform
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            specialFloor.name = "castlePlatform";
            specialFloor.transform.SetParent(this.transform);
            /*spawnPlatformPoint += sizePlatform;*/                 //was finish don't use
            allPlatformGame.Add(specialFloor);
        }

        // special platform Castle
        else if( typePlatform == 4)
        {
            GameObject specialFloor = Instantiate(platform[9], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                          //Random Trap platform
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            specialFloor.name = "castlePlatform";
            specialFloor.transform.SetParent(this.transform);
            /*spawnPlatformPoint += sizePlatform;*/                 //was finish don't use
            allPlatformGame.Add(specialFloor);
        }
    }
    #endregion
    #region deletePlatform
    void DeleteOldplatform()
    {
        if (playerPos.position.z > allPlatformGame[0].transform.position.z + sizePlatform*1)
        {
            Debug.Log("delete Floor");
            Destroy(allPlatformGame[0]);
            allPlatformGame.RemoveAt(0);
        }
    }
    #endregion

    #region reset Platform status when Start Gameplay
    void ResetStatusTileManager()
    {
        EndRewardQuest.isCameraViewToplayer = false;
        EndDistanceQuest.isCameraViewToplayer = false;
        questDistance = false;
        questCollect = false;
        dungeonStage = false;
    }
    #endregion

    #region TerrianControl
    void startTerrian()
    {
        PosTerrianPlayerFirst += 400;
        switch (stage)
        {
            case 1: case 2:
                starterTerrian = terrainType[0];
                break;
            case 3: case 4:
                starterTerrian = terrainType[1];
                break;
            case 5: case 6:
                starterTerrian = terrainType[2];
                break;
        }

        for (int i = 0; i < 2; i++)
        {
            GameObject terrianInstance = Instantiate(starterTerrian,starterTerrianPoint.GetChild(i).transform.position,starterTerrian.transform.rotation);
            terrianInstance.name = "terrian" + (i + 1); 
        }
    }

    void MoveTerrianFollowPlayer()
    {
        if (playerPos.position.z >= PosTerrianPlayerSecond)
        {
            PosTerrianPlayerSecond += nextMoveTerrianZ;
            Transform terrianInstance1 = GameObject.Find("terrian1").transform;
            terrianInstance1.position = new Vector3(terrianInstance1.position.x,
                terrianInstance1.position.y,PosTerrianPlayerFirst);

        }
        if (playerPos.position.z >= PosTerrianPlayerFirst)
        {
            PosTerrianPlayerFirst += nextMoveTerrianZ;
            Transform terrianInstance2 = GameObject.Find("terrian2").transform;
            terrianInstance2.position = new Vector3(terrianInstance2.position.x,
                terrianInstance2.position.y,PosTerrianPlayerSecond);
        }
    }
    #endregion
 #endregion

    #region randomPlatformObstacleOrSpawn
    void RandomPlatformObstacleOrSpawnGreenField(int resultRandom)
    {
            switch (resultRandom)
            {
            case 1:
                int randomtype = Random.Range(0, 5);
                GameObject obstaclePlatform = Instantiate(typePlatformObstacleGreen[randomtype], new Vector3(
                                              starterplatform.position.x,
                                              starterplatform.position.y,                                                     //Random Normal platform
                                              spawnPlatformPoint),
                                          starterplatform.rotation) as GameObject;
                obstaclePlatform.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(obstaclePlatform);
                break;
            case 2:
                GameObject spawnPlatform = Instantiate(typeSpawnGreen[0], new Vector3(
                                                   starterplatform.position.x,
                                                   starterplatform.position.y,                                                     //Random Normal platform
                                                   spawnPlatformPoint),
                                               starterplatform.rotation) as GameObject;
                spawnPlatform.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(spawnPlatform);
                break;
            }
    }

    void RandomPlatformObstacleOrSpawnBlackForest(int resultRandom)
    {
        switch (resultRandom)
        {
            case 1:
                int randomtype = Random.Range(0, 6);
                GameObject obstaclePlatform = Instantiate(typePlatformObstacleBlack[randomtype], new Vector3(
                    starterplatform.position.x,
                    starterplatform.position.y,                                                     //Random Normal platform
                    spawnPlatformPoint),
                    starterplatform.rotation) as GameObject;
                obstaclePlatform.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(obstaclePlatform);
                break;
            case 2:
                GameObject spawnPlatform = Instantiate(typeSpawnBlack[0], new Vector3(
                    starterplatform.position.x,
                    starterplatform.position.y,                                                     //Random Normal platform
                    spawnPlatformPoint),
                    starterplatform.rotation) as GameObject;
                spawnPlatform.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(spawnPlatform);
                break;
        }
    }
    void RandomPlatformObstacleOrSpawnRedVolcano(int resultRandom)
    {
        switch (resultRandom)
        {
            case 1:
                int randomtype = Random.Range(0, 5);
                GameObject obstaclePlatform = Instantiate(typePlatformObstacleRed[randomtype], new Vector3(
                    starterplatform.position.x,
                    starterplatform.position.y,                                                     //Random Normal platform
                    spawnPlatformPoint),
                    starterplatform.rotation) as GameObject;
                obstaclePlatform.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(obstaclePlatform);
                break;
            case 2:
                GameObject spawnPlatform = Instantiate(typeSpawnRed[0], new Vector3(
                    starterplatform.position.x,
                    starterplatform.position.y,                                                     //Random Normal platform
                    spawnPlatformPoint),
                    starterplatform.rotation) as GameObject;
                spawnPlatform.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(spawnPlatform);
                break;
        }
    }
    #endregion
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour {

    public GameObject[] platform;
    public Transform starterplatform;

    public GameObject[] trap;

    float spawnPlatformPoint = 8.696283f;                       // point for Spawn first platform  
    float sizePlatform = 8.696283f;


    Transform playerPos;
    float arriveZone = 40f;                                 //set more if want to spawn more platform
    List<GameObject> allPlatformGame;

    public GameObject boss;

    public static bool dungeonStage = false;
    public static bool bossStage = false;
    public static bool QuestStage = false;

    public static bool EndStage = false;

	void Start () {                                                         //Spawn StarterPlatform when start Game
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
            Debug.Log("start platform");
        }
	}
	
	void Update () {
        DistanceSpawnPlatform();
	}

    #region Platform from distance
    void DistanceSpawnPlatform()
    {
        if (playerPos.position.z +arriveZone  >= spawnPlatformPoint && dungeonStage == false && bossStage == false && QuestStage == false && EndStage == false) //allow front point player Check to The last edge platform
        {
            Spawnplatform(1);           // clone (normal platform)
            DeleteOldplatform();        // delete (Old platform)
        }

        else if (playerPos.position.z +arriveZone  >= spawnPlatformPoint && dungeonStage == true) //allow front point player Check to The last edge platform
        {
            Spawnplatform(2);           // clone (dungeon platform)
            DeleteOldplatform();        // delete (Old platform)
        }

        else if (playerPos.position.z +arriveZone  >= spawnPlatformPoint && dungeonStage == false && bossStage == true) //allow front point player Check to The last edge platform
        {
            Spawnplatform(0);           // clone (empty platform)
            DeleteOldplatform();        // delete (Old platform)
            if (BossBehavior.isBossApprea == false )
            {
                Debug.Log("spawnBoss");
                GameObject bossGameplay = Instantiate(boss);
                bossGameplay.name = "Boss";
            }
        }
        else if (playerPos.position.z +arriveZone  >= spawnPlatformPoint && dungeonStage == false && bossStage == false && QuestStage == true && EndStage == false) //allow front point player Check to The last edge platform
        {
            Debug.Log("Complete Stage");
            Spawnplatform(0);
            Spawnplatform(0);
            Spawnplatform(3);           // clone (empty platform)
            DeleteOldplatform();        // delete (Old platform)
            EndStage = true;
        }
    }
    #endregion

    #region TypePlatform Function
    void Spawnplatform(int typePlatform)
    {
        if (typePlatform == 0)                 
        {
            GameObject floor = Instantiate(platform[0], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                         //Starter Platform
                spawnPlatformPoint),                                                                            //Continue with z pos
                starterplatform.rotation) as GameObject;
            floor.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(floor);
        }
        else if( typePlatform == 1)
        {
            int randomNormalplatform = Random.Range(1, 7);
            GameObject floor = Instantiate(platform[randomNormalplatform], new Vector3(
                                       starterplatform.position.x,
                                       starterplatform.position.y,                                                     //Random Normal platform
                                       spawnPlatformPoint),
                                   starterplatform.rotation) as GameObject;
                floor.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(floor);
        }
        else if( typePlatform == 2)
        {
            /*int randomTrapPlatform = Random.Range(7, 8);*/                        //if want more TrapPlatform Check this
            GameObject trapFloor = Instantiate(platform[7], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                          //Random Trap platform
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            trapFloor.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(trapFloor);
        }
        else if( typePlatform == 3)
        {
            GameObject specialFloor = Instantiate(platform[8], new Vector3(
                starterplatform.position.x,
                starterplatform.position.y,                                                                          //Random Trap platform
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            specialFloor.name = "victoryPlatform";
            specialFloor.transform.SetParent(this.transform);
            /*spawnPlatformPoint += sizePlatform;*/                 //was finish don't use
            allPlatformGame.Add(specialFloor);
        }
    }
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
}

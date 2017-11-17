using System.Collections;
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

    bool SpawnTrap = true;

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
        
        if (playerPos.position.z +arriveZone  >= spawnPlatformPoint && SpawnTrap == false) //allow front point player Check to The last edge platform
        {
                Spawnplatform(1);           // clone (New platform)
                DeleteOldplatform();        // delete (Old platform)
        }

        else if (playerPos.position.z +arriveZone  >= spawnPlatformPoint && SpawnTrap == true) //allow front point player Check to The last edge platform
        {
            Spawnplatform(2);           // clone (New platform)
            DeleteOldplatform();        // delete (Old platform)
        }

	}
    void Spawnplatform(int isRandom)
    {
        if (isRandom == 0)                 
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
        else if( isRandom == 1)
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
        else if( isRandom == 2)
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
    }
    void DeleteOldplatform()
    {
        if (playerPos.position.z > allPlatformGame[0].transform.position.z + sizePlatform*3)
        {
            Debug.Log("delete Floor");
            Destroy(allPlatformGame[0]);
            allPlatformGame.RemoveAt(0);
        }
    }


}

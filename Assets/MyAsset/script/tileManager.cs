using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour {

    public GameObject[] platform;

    public Transform starterplatform;

    float spawnPlatformPoint = 8.696283f;                       // point for Spawn first platform  
    float sizePlatform = 8.696283f;


    public Transform playerPos;
    float arriveZone = 40f;
    List<GameObject> allPlatformGame;

	void Start () {
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
        
        if (playerPos.position.z +arriveZone >= spawnPlatformPoint) //arrow front point player Check to The last edge platform
        {
                Spawnplatform(1);           // clone (New platform)
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
                spawnPlatformPoint),
                starterplatform.rotation) as GameObject;
            floor.transform.SetParent(this.transform);
            spawnPlatformPoint += sizePlatform;
            allPlatformGame.Add(floor);
        }
        else
        {
            int randomNumplatform = Random.Range(1, 7);
                GameObject floor = Instantiate(platform[randomNumplatform], new Vector3(
                                       starterplatform.position.x,
                                       starterplatform.position.y,                                                     //Random platform
                                       spawnPlatformPoint),
                                   starterplatform.rotation) as GameObject;
                floor.transform.SetParent(this.transform);
                spawnPlatformPoint += sizePlatform;
                allPlatformGame.Add(floor);
        }
    }

    void DeleteOldplatform()
    {
        Debug.Log("delete Floor");
        Destroy(allPlatformGame[0]);
        allPlatformGame.RemoveAt(0);
    }


}

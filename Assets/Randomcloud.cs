using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomcloud : MonoBehaviour {

    public int numCloud;
    int maxNumCloud;
    public GameObject cloud;
    RectTransform cloudCLonePosition;
    string lastSideSpawnCloud;

    int randomPosX;
    int randomOffsetX;
    int randomPosY;
    RectTransform RT;

    void Start () {
        maxNumCloud = numCloud;
        SpawnCloud(numCloud);
    }

    void Update()
    {
        if (numCloud <= 0)
        {
            numCloud = maxNumCloud;
            SpawnCloud(maxNumCloud);

        }
    }

    void SpawnCloud(int numSpawn)
    {
        for (int i = 0; i < numSpawn; i++)
        {
            randomOffsetX =  Random.Range(1, 500);
        if (lastSideSpawnCloud == null)
        {
            int randomSideX = Random.Range(1, 3);
            switch (randomSideX)
            {
                case 1:
                        randomPosX = -700 - randomOffsetX;
                    break;
                case 2:
                        randomPosX = 700 + randomOffsetX;
                    break;
            }
            randomPosY = Random.Range(-300, 301);
            
            if (randomSideX == 1)
            {
                GameObject cloudClone = Instantiate(cloud);
                cloudClone.transform.SetParent(GameObject.Find("Canvas").transform);
                cloudClone.GetComponent<RectTransform>().localPosition = new Vector3(randomPosX, randomPosY, 0);
                cloudClone.GetComponent<MoveCloud>().moveDirectionTo = "moveToRight";
                lastSideSpawnCloud = "left";
            }
            else if (randomSideX == 2)
            {
                    GameObject cloudClone = Instantiate(cloud);
                cloudClone.transform.SetParent(GameObject.Find("Canvas").transform);
                cloudClone.GetComponent<RectTransform>().localPosition = new Vector3(randomPosX, randomPosY, 0);
                cloudClone.GetComponent<MoveCloud>().moveDirectionTo = "moveToLeft";
                lastSideSpawnCloud = "right";
            }
        }
        else if(lastSideSpawnCloud == "left")
        {
                int randomNewPosY = Random.Range(-300, 301);
                GameObject cloudClone = Instantiate(cloud);
            cloudClone.transform.SetParent(GameObject.Find("Canvas").transform);
                //new cloud should be right
                cloudClone.GetComponent<RectTransform>().localPosition = new Vector3(700 + randomOffsetX, randomNewPosY, 0);
            cloudClone.GetComponent<MoveCloud>().moveDirectionTo = "moveToLeft";
                lastSideSpawnCloud = "right";
        }

            else if(lastSideSpawnCloud == "right")
        {
                int randomNewPosY = Random.Range(-300, 301);
            GameObject cloudClone = Instantiate(cloud);
            cloudClone.transform.SetParent(GameObject.Find("Canvas").transform);
                //new cloud should be left
                cloudClone.GetComponent<RectTransform>().localPosition = new Vector3(-700 - randomOffsetX, randomNewPosY, 0);
                cloudClone.GetComponent<MoveCloud>().moveDirectionTo = "moveToRight";
                lastSideSpawnCloud = "left";
        }
        }
    }
}

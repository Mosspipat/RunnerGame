using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatformDarkForest : MonoBehaviour {


    public static bool canGateSpawn;
    public GameObject door;
    public Transform doorPoint;

    public GameObject[] fallenTrap;
    bool canFallObject  = true;
    int rangeOffset = 10;

    public GameObject spear;
    public Transform[] posSpear;

    void Start()
    {
        SpawnGate();
        SpawnSpear();  
    }

	void Update () {
        RandomFallenObject();
	}

    public void RandomFallenObject()
    {
        if (GameObject.Find("player").transform.position.z > this.transform.position.z - rangeOffset && canFallObject)
        {
            canFallObject = false;
            int randomObjectNum = Random.Range(1, 5);

            switch (randomObjectNum)
            {
                case 1:
                    fallenTrap[0].transform.Find("prop").GetComponent<Animator>().SetTrigger("isFall");
                    break;
                case 2:
                    fallenTrap[1].transform.Find("prop").GetComponent<Animator>().SetTrigger("isFall");
                    break;
                case 3:
                    fallenTrap[2].transform.Find("prop").GetComponent<Animator>().SetTrigger("isFall");
                    break;
                case 4:
                    fallenTrap[3].transform.Find("prop").GetComponent<Animator>().SetTrigger("isFall");
                    break;
            }
        }
    }

    public void SpawnSpear()
    {
        int occasionSpearApprea = Random.Range(1, 2);
        if (occasionSpearApprea == 1)
        {
            GameObject spearDungeon = Instantiate(spear, posSpear[Random.Range(0, 3)].position, spear.transform.rotation);
            spearDungeon.transform.SetParent(this.transform);
        }
    }

    public void SpawnGate()
    {
        if (canGateSpawn)
        {
            Debug.Log("gateSpawn");
            GameObject gateDungeon = Instantiate(door, doorPoint.transform.position, door.transform.rotation);
            gateDungeon.transform.SetParent(this.transform);
            canGateSpawn = false;
        }
    }
}

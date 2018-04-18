using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatformTwo : MonoBehaviour {

    public List<GameObject> TrapType;
    public Transform spawnPointer;
    int[] listNumSpawnPoint = new int[]{0,3,6,2,5,8};

	void Start () {
        int randomTrapType = Random.Range(1, 2);
        switch (randomTrapType)
        {
        //Left Right "pole"
            case 1:
                int randomSpawnPoint = Random.Range(1,7);
                //left Side Spawn
                if (randomSpawnPoint == 1 || randomSpawnPoint == 2 || randomSpawnPoint == 3)
                {
                    Debug.Log("left at"+randomSpawnPoint);
                    GameObject poleLeft = Instantiate(TrapType[0], spawnPointer.GetChild(listNumSpawnPoint[randomSpawnPoint-1]).transform.position + Vector3.up *-0.5f, TrapType[0].transform.rotation);
                }
                //right Side Spawn
                else if(randomSpawnPoint == 4 || randomSpawnPoint == 5 || randomSpawnPoint == 6)
                {
                    Debug.Log("right at"+randomSpawnPoint);
                    GameObject poleRight = Instantiate(TrapType[0], spawnPointer.GetChild(listNumSpawnPoint[randomSpawnPoint-1]).transform.position + Vector3.up *-0.5f, TrapType[0].transform.rotation * Quaternion.Euler(0,180,0));
                }
                break;
        // Middle "Pole"
            case 2:
                GameObject middlePole = Instantiate(TrapType[1], spawnPointer.GetChild(4).transform.position, spawnPointer.GetChild(4).transform.rotation);
                break;
        }
	}
}

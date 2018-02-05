using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatformTwo : MonoBehaviour {

    public List<GameObject> TrapType;
    public Transform spawnPointer;
    public int[] listNumSpawnPoint = new int[]{0,2,3,5,6,8};

	void Start () {
        int randomTrapType = Random.Range(1, 2);
        switch (randomTrapType)
        {
        //Left Right "pole"
            case 1:
                int randomSpawnPoint = Random.Range(0, listNumSpawnPoint.Length);
                //left Side Spawn
                if (randomSpawnPoint == 0 || randomSpawnPoint == 3 || randomSpawnPoint == 6)
                {
                    GameObject poleLeft = Instantiate(TrapType[0], spawnPointer.GetChild(listNumSpawnPoint[randomSpawnPoint]).transform.position, spawnPointer.GetChild(listNumSpawnPoint[randomSpawnPoint]).transform.rotation);
                }
                //right Side Spawn
                else 
                {
                    Debug.Log(randomSpawnPoint + " rightSide");
                    GameObject poleRight = Instantiate(TrapType[0], spawnPointer.GetChild(listNumSpawnPoint[randomSpawnPoint]).transform.position, spawnPointer.GetChild(listNumSpawnPoint[randomSpawnPoint]).transform.rotation);
                    poleRight.transform.Rotate(Vector3.up* 180f);
                }
                break;
        // Middle "Pole"
            case 2:
                GameObject middlePole = Instantiate(TrapType[1], spawnPointer.GetChild(4).transform.position, spawnPointer.GetChild(4).transform.rotation);
                break;
        }
	}
	
	void Update () {
	}
}

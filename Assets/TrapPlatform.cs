using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour {

    public GameObject[] trap;

	void Start () {
        int randomTrapType = Random.Range(1,4);

        switch (randomTrapType)
        {
            case 1:
                Debug.Log("floorTrap");
                GameObject trapFloor = Instantiate(trap[2], this.transform.Find("trapPosFloor/trapPointMiddleM").transform.position + Vector3.left * 2.5f, trap[2].transform.rotation);
                trapFloor.transform.SetParent(this.transform);
                break;
            case 2:
                Debug.Log("wallTrap");
                int randomLeftOrRight = Random.Range(1, 3);
                if (randomLeftOrRight == 1)
                {
                    Debug.Log("LeftTrap spawn");
                    GameObject trapWall = Instantiate(trap[0],this.transform.Find("trapPosFloor/trapPointFrontL").transform.position,trap[0].transform.rotation);
                    trapWall.transform.SetParent(this.transform);
                }
                else
                {
                    Debug.Log("RightTrap spawn");
                    GameObject trapWall = Instantiate(trap[1],this.transform.Find("trapPosFloor/trapPointFrontR").transform.position,trap[1].transform.rotation);
                    trapWall.transform.SetParent(this.transform);
                }
                break;
            case 3:
                Debug.Log("roofTrap");
                GameObject trapRoof = Instantiate(trap[3], this.transform.Find("trapPosFloor/trapPointMiddleM").transform.position + Vector3.up * 4, trap[3].transform.rotation);
                trapRoof.transform.SetParent(this.transform);
                break;
        }
	}
	
}

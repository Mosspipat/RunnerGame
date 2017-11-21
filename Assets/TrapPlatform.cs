using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour {

    public GameObject[] traps;
    public GameObject[] props;

    public static bool gateSpawn = true;
    public static bool canGateSpawn;

    void Start () {

        GateSpawn();
       
        int randomTrapType = Random.Range(1,4);

        switch (randomTrapType)
        {
            case 1:
                Debug.Log("floorTrap");
                int randomRotation = Random.Range(1, 3);
                if (randomRotation == 1)
                {
                    GameObject trapFloor = Instantiate(traps[2], this.transform.Find("trapPosFloor/trapPointMiddleL").transform.position, traps[2].transform.rotation * Quaternion.Euler(0, 0, 0));
                    trapFloor.transform.SetParent(this.transform);
                }
                else
                {
                    GameObject trapFloor = Instantiate(traps[2], this.transform.Find("trapPosFloor/trapPointMiddleR").transform.position, traps[2].transform.rotation * Quaternion.Euler(0, 180, 0));
                    trapFloor.transform.SetParent(this.transform);
                }
                break;
            case 2:
                Debug.Log("wallTrap");
                int randomLeftOrRight = Random.Range(1, 3);
                if (randomLeftOrRight == 1)
                {
                    Debug.Log("LeftTrap spawn");
                    GameObject trapWall = Instantiate(traps[0],this.transform.Find("trapPosFloor/trapPointFrontL").transform.position+Vector3.up*1,traps[0].transform.rotation);
                    trapWall.transform.SetParent(this.transform);
                }
                else
                {
                    Debug.Log("RightTrap spawn");
                    GameObject trapWall = Instantiate(traps[1],this.transform.Find("trapPosFloor/trapPointFrontR").transform.position+Vector3.up*1,traps[1].transform.rotation);
                    trapWall.transform.SetParent(this.transform);
                }
                break;
            case 3:
                Debug.Log("roofTrap");
                int RandomSideSwitch = Random.Range(1, 3);
                if (RandomSideSwitch == 1)
                {
                    GameObject trapRoof = Instantiate(traps[3], this.transform.Find("trapPosFloor/trapPointMiddleM").transform.position + Vector3.up * 4, traps[3].transform.rotation);
                    trapRoof.transform.SetParent(this.transform);
                }
                else
                {
                    GameObject trapRoof = Instantiate(traps[3], this.transform.Find("trapPosFloor/trapPointMiddleM").transform.position + Vector3.up * 4, traps[3].transform.rotation * Quaternion.Euler(0, 180, 0));
                    trapRoof.transform.SetParent(this.transform);
                }
                break;
        }
    }
    #region propsDungon
    void GateSpawn()
    {
        if (gateSpawn == true && canGateSpawn == true )
        {
            Debug.Log("gate Spawn");
            GameObject gate = Instantiate(props[0], this.transform.Find("frontPos").transform.position, props[0].transform.rotation);
            gate.transform.SetParent(this.transform);
            gateSpawn = false;
        }
    }
    #endregion
	
}

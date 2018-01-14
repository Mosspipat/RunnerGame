using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSlot : MonoBehaviour {

    public Transform allSlot;
    public GameObject subMission;

	void Start () {
        GameObject submissionClone = Instantiate(subMission,allSlot.GetChild(0).transform.position,subMission.transform.rotation);
        submissionClone.transform.SetParent(allSlot.GetChild(0));
        submissionClone.transform.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
	}
	
	void Update () {
		
	}

    void FindBoxMission()
    {
        
    }

}

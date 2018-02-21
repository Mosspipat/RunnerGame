using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandCusorCheck : MonoBehaviour {

	void Update () {
        CheckClickWithObject();
        CheckRay();
	}

    void CheckClickWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, gameObject.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
        }
    }

    void CheckRay()
    {
        Debug.DrawRay(this.transform.position, this.gameObject.transform.forward*10000f, Color.green);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMainKinect : MonoBehaviour {

    private static MyMainKinect instanceMyMainKinect;

    void Awake()
    {
        if (!instanceMyMainKinect)
        {
            instanceMyMainKinect = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

	}

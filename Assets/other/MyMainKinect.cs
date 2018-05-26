using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMainKinect : MonoBehaviour {

    private static MyMainKinect instanceMyMainKinect;

    public KinectManager kinectManage;

    float fullTime = 1f;
    float time;

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

    void Start()
    {
        time = fullTime;
    }

    void Update()
    {
        time -= 1 * Time.deltaTime;

        if (time <= 0)
        {
            ResetKinect();
            time = fullTime;
        }
    }

    void ResetKinect()
    {
        kinectManage.enabled = false;
        StartCoroutine(StartKinect());
        Debug.Log("kinect closed");
    }

    IEnumerator StartKinect()
    {
        yield return new WaitForSeconds(0.0001f);
        kinectManage.enabled = true;
        Debug.Log("kinect startUP!!");
    }

	}

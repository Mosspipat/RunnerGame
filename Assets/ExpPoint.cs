using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour {

    Transform UIExpBar; 
    bool setAction = true;
    float actionTime = 0.5f;
    bool action;

	void Start () {
        UIExpBar = GameObject.Find("Main Camera/ProgressPlayer/ProgressExpPlayer/getExpPoint").transform.GetComponent<Transform>();
        Destroy(this.gameObject, 1f);
    }
	
	void Update () {
        Action();
    }

    #region Action
    void Action ()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * 100f);
        actionTime -= Time.deltaTime;
        if (setAction&&actionTime<=0)
        {
            setAction = false;
            action = true;
        }
        else if (action)
        {
            Debug.Log("Gain EXP");
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = true;
            transform.position = Vector3.Lerp(this.transform.position, UIExpBar.position, 10f * Time.deltaTime);
        } 
    }

    void OnDestroy()
    {
        int newExp = PlayerPrefs.GetInt("expPlayer");
        newExp++;
        PlayerPrefs.SetInt("expPlayer", newExp);
    }

    #endregion


}

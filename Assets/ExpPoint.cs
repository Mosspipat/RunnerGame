using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour {

    Transform UIExpBar;
    Animator animexpBar;
    bool setAction = true;
    float actionTime = 0.5f;
    bool action;

	void Start () {
        UIExpBar = GameObject.Find("MainCamera/ProgressPlayer/ProgressExpPlayer/getExpPoint").transform.GetComponent<Transform>();
        animexpBar = GameObject.Find("MainCamera/ProgressPlayer/ProgressExpPlayer").transform.GetComponent<Animator>();
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
        animexpBar.SetTrigger("isActive");
        Debug.Log("animation Exp");
        PlayerPrefs.SetInt("expPlayer", newExp);
    }

    #endregion


}

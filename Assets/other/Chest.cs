using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject item;
    public Transform itemPoint;
    bool isSpawnItem;
    GameObject itemReward;

    Transform TotalScoreUI;

	void Start () {
        TotalScoreUI = GameObject.Find("Main Camera/ProgressPlayer/totalScore").transform;
	}
	
	void Update () {
        if (itemReward == true)
        {
            itemReward.transform.position = itemPoint.transform.position;    
        }
    }

    #region Chest EventsAnimation
    public void SpawnItem()
    {
        itemReward = Instantiate(item, itemPoint.transform.position,item.transform.rotation);
        isSpawnItem = true;
    }
    public void ShowScoreUI()
    {
        TotalScoreUI.gameObject.SetActive(true);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEffect : MonoBehaviour {

    public static List <GameObject> allCoins;

	void Start () {
        allCoins = new List<GameObject>();
	}
	
	void Update () {
        MagnetEffectWork();
	}

    void MagnetEffectWork()
    {
        if(playerController.isMagnetEffect == true)
        {
            foreach (GameObject coins in allCoins)
            {
                if (Vector3.Distance(coins.transform.position, this.transform.position) < 10f)
                {
                    coins.transform.position = Vector3.Lerp(coins.transform.position,
                    this.transform.position, 2f * Time.deltaTime);
                }
            }
        }
    }

}

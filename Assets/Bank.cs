using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bank : MonoBehaviour {

	void Update () {
        if (PlayerPrefs.GetInt("money") <= 0)
        {
            PlayerPrefs.SetInt("money",0);
        }
        transform.Find("panelBank/textBank").GetComponent<Text>().text = "Yours coins : \n" + PlayerPrefs.GetInt("money").ToString();
	}
}

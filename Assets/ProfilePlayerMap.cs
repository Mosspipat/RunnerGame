using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePlayerMap : MonoBehaviour {

    public Text levelPlayer;
    public Image imageEXP;
    public Text expText;
    int maxExpInt;

    public Text coinPlayer;
	
    void Start () {
        levelPlayer.GetComponent<Text>();
        imageEXP.GetComponent<Image>();
        expText.GetComponent<Text>();
        coinPlayer.GetComponent<Text>();
	}
	
	void Update () {
        levelPlayer.text = "Level Player : " + PlayerPrefs.GetInt("levelPlayer").ToString();
        expText.text = "Exp : " + PlayerPrefs.GetInt("expPlayer") + " / " + (10 * (Mathf.Pow(2, PlayerPrefs.GetInt("levelPlayer") - 1)));
        imageEXP.fillAmount = PlayerPrefs.GetInt("expPlayer") / (10 * (Mathf.Pow(2, PlayerPrefs.GetInt("levelPlayer") - 1)));
        coinPlayer.text = "Coins : " + PlayerPrefs.GetInt("money").ToString() + " coins";
	}

}

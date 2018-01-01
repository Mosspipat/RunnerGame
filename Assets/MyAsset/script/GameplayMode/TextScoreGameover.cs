using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScoreGameover : MonoBehaviour {

    ScoreManagerAndEvent SGgetScore;
    public Text textShowScore;
    public Text textshowBestScore;
	
    void Start () {
        SGgetScore = GameObject.Find("gameManager").GetComponent<ScoreManagerAndEvent>();
    }
	
	void Update () {
        textShowScore.text = SGgetScore.score.ToString() + " meter";
        textshowBestScore.text = "best score : " + PlayerPrefs.GetInt(SGgetScore.keyBestScore).ToString() + " meter";
	}
}

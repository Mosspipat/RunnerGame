using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScoreGameover : MonoBehaviour {

    ScoreManager SGgetScore;
    public Text textShowScore;
    public Text textshowBestScore;
	
    void Start () {
        SGgetScore = GameObject.Find("gameManager").GetComponent<ScoreManager>();
    }
	
	void Update () {
        textShowScore.text = SGgetScore.score.ToString();
        textshowBestScore.text = PlayerPrefs.GetInt(SGgetScore.keyBestScore).ToString();
	}
}

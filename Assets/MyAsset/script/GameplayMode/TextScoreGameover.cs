using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScoreGameover : MonoBehaviour {

    public static bool isShowScore;

    Text textShowScore;
    Text textshowBestScore;
    
    void Update () {
        ShowScore();
    }

    void ShowScore()
    {
        if (isShowScore)
        {
            textShowScore = transform.Find("panelTotalScore/scoreText").transform.GetComponent<Text>();
            textshowBestScore = transform.Find("panelTotalScore/bestScoreText").transform.GetComponent<Text>();
            textShowScore.text = ScoreManagerAndEvent.score.ToString() + " meter";
            textshowBestScore.text = "best score : " + PlayerPrefs.GetInt(ScoreManagerAndEvent.keyBestScore).ToString() + " meter";
            isShowScore = false;
        }
    }
}

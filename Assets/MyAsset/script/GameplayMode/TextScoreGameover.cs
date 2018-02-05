using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScoreGameover : MonoBehaviour {

    SelectionScene SelectScene;
    public static bool isShowScore;

    Text textShowScore;
    Text textshowBestScore;

    void Start()
    {
        SelectScene = GameObject.Find("SceneSelectManager").GetComponent<SelectionScene>();
    }

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

    #region PressToMenu
    public void BacktoMenu()
    {
        Application.LoadLevel("menuMap");
    }
    #endregion
}

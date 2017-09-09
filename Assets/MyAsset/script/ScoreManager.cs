using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {


    public string  keyBestScore = "bestScore";
    public int score ;
    public int bestScore; 
    UIPlayer TSscoreGame;
    playerController PCstatusPlayer;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PCstatusPlayer = GameObject.Find("player").GetComponent<playerController>();
        TSscoreGame = GameObject.Find("player").transform.GetChild(3).GetChild(0).transform.GetComponent<UIPlayer>();   // or Use getComponentInChildren
        Debug.Log("bestScore: " +PlayerPrefs.GetInt(keyBestScore));
    }


	void Update()
    {
        Debug.Log(score);
        if (PCstatusPlayer.isDead)
        {
            score = TSscoreGame.intergerScore;
        }
        else if (TSscoreGame.intergerScore >= PlayerPrefs.GetInt(keyBestScore))
        {
            bestScore = TSscoreGame.intergerScore;
            PlayerPrefs.SetInt(keyBestScore, bestScore);
            Debug.Log("winner");
        }
    }

}

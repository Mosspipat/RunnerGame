using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerAndEvent : MonoBehaviour {

    private static ScoreManagerAndEvent scoreManager_Instance;
    public static string  keyBestScore = "bestScore";
    public static int score ;
    public static int bestScore; 
    UIPlayer TSscoreGame;
    playerController PCstatusPlayer;

    public static bool isDead = false;

    void Awake()
    {
        if (!scoreManager_Instance)
        {
            scoreManager_Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        PCstatusPlayer = GameObject.Find("player").GetComponent<playerController>();
        TSscoreGame = GameObject.Find("player").transform.GetChild(3).GetChild(0).transform.GetComponent<UIPlayer>();   // or Use getComponentInChildren
       // Debug.Log("bestScore: " +PlayerPrefs.GetInt(keyBestScore));
    }


	void Update()
    {
        if (isDead == true)
        {
            score = UIPlayer.intergerScore;
        }
        else if (UIPlayer.intergerScore >= PlayerPrefs.GetInt(keyBestScore))
        {
            bestScore = UIPlayer.intergerScore;
            PlayerPrefs.SetInt(keyBestScore, bestScore);
            Debug.Log("winner");
        }
    }
}

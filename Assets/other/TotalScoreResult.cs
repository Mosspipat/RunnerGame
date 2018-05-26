using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreResult : MonoBehaviour {

    UIPlayer uiplayer;

    Text scoreDistance;
    Text scoreKill;
    Text scoreCoin;
    Text scoreResult;

    int scoreDistanceInt;
    int scoreKillInt ;
    int scoreCoinInt ;
    int scoreResultInt;

    float speedChecker;

	void Start () {

        uiplayer = GameObject.Find("player/UIPlayer").GetComponent<UIPlayer>();

        scoreDistance = GameObject.Find("ScorePanel/distanceText/score").GetComponent<Text>();
        scoreKill = GameObject.Find("ScorePanel/monsterKilledText/score").GetComponent<Text>();
        scoreCoin = GameObject.Find("ScorePanel/coinText/score").GetComponent<Text>();
        scoreResult = GameObject.Find("totalScoreText/score").GetComponent<Text>();

	}
	
	void Update () {
        speedChecker += 100 * Time.deltaTime;

        ScoreRunScoreResult();
	}

    #region RunScoreResult
    void ScoreRunScoreResult()
    {
        ScoreRunDistance();
    }

    void ScoreRunDistance()
    {
        scoreDistance.text = scoreDistanceInt.ToString();

        if (scoreDistanceInt <= uiplayer.intergerScore/*UIPlayer.intergerScoreCoin*/)
        {
            scoreDistanceInt += (int)(Time.deltaTime * speedChecker);
        }
        else
        {
            scoreDistance.text = uiplayer.intergerScore.ToString();
            Invoke("ScoreRunKill", 1f);
        }
    }
    void ScoreRunKill()
    {
        scoreKill.text = scoreKillInt.ToString();

        if (scoreKillInt <= uiplayer.amountMonsterKilled/*UIPlayer.intergerScoreCoin*/)
        {
            scoreKillInt += (int)(Time.deltaTime * speedChecker);
        }
        else
        {
            scoreKill.text = uiplayer.amountMonsterKilled.ToString();
            Invoke("ScoreRunCoin", 1f);
        }
    }
    void ScoreRunCoin()
    {
        scoreCoin.text = scoreCoinInt.ToString();

        if (scoreCoinInt <= uiplayer.intergerScoreCoin)
        {
            scoreCoinInt += (int)(Time.deltaTime * speedChecker);
        }
        else
        {
            scoreCoin.text = uiplayer.intergerScoreCoin.ToString();
            Invoke("ScoreResult", 1f);
        }
    }

    void ScoreResult()
    {
        scoreResult.text = (uiplayer.intergerScore+uiplayer.amountMonsterKilled+uiplayer.intergerScoreCoin).ToString();
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour {

    float score = 0;
    public int intergerScore{ set; get;}
    public Text scoreText;

    ScoreManager TSscoreGame;
    playerController PCstatusPlayer;
    public Transform player;

    void Start () {
        score = 0;
	}
	
    /*void FixedUpdate()
    {
        this.transform.position = new Vector3(player.transform.position.x+3f,player.transform.position.y+2.5f,player.transform.position.z);
        this.transform.localScale = new Vector3(-0.05f ,0.05f, 0.05f);
        this.transform.LookAt(Camera.main.transform);
    }*/

    void Update () {
        scoreText.text = intergerScore.ToString()+" mile";
        RunScore();
	}

    void RunScore()
    {
        score += 1 * Time.deltaTime;
        intergerScore = (int)score / 1;
    }

}

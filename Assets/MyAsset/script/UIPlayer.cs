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

    public enum Stages
    {
        normal,
        dungeon
    };

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

        //EventGameplay();
	}

    void RunScore()
    {
        score += 1 * Time.deltaTime;
        intergerScore = (int)score / 1;
    }


    #region SpecialEvent
    void EventGameplay()
    {
        if (intergerScore %10 == 0 && intergerScore !=0)       //Bonus Stage and will not start gameplay's starter
        {
            Debug.Log("open Dungeon");
            tileManager.dungeonStage = true;
            TrapPlatform.canGateSpawn = true;
            Invoke("CloseDungeon", 5f);
        }

        if (intergerScore %10 == 0 && intergerScore !=0)       //Bonus Stage and will not start gameplay's starter
        {
            Debug.Log("open boss stage");
            /* tileManager.dungeonStage = true;
            TrapPlatform.canGateSpawn = true;*/

            Invoke("CloseBoss", 5f);
        }


    }

    void CloseDungeon()
    {
        tileManager.dungeonStage = false;
        TrapPlatform.gateSpawn = true;
    }

    void CloseBoss()
    {
        tileManager.dungeonStage = false;
        TrapPlatform.gateSpawn = true;
    }

    #endregion

}

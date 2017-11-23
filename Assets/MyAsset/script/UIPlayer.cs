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

        EventGameplay();
	}

    void RunScore()
    {
        score += 1 * Time.deltaTime;
        intergerScore = (int)score / 1;
    }


    #region SpecialEvent
    void EventGameplay()
    {
        if (intergerScore %50 == 0 && intergerScore !=0 && tileManager.bossStage == false)       //Bonus Stage and will not start gameplay's starter
        {                                                                                       // check it boss stage will not spawn Dungeon Stage
            Debug.Log("open Dungeon");
            TrapPlatform.canGateSpawn = true;
            tileManager.dungeonStage = true;
            Invoke("CloseDungeon", 10f);
        }

        if (intergerScore %140 == 0 && intergerScore !=0 && tileManager.dungeonStage == false)       //Bonus Stage and will not start gameplay's starter
        {
            Debug.Log("open boss stage");
            tileManager.dungeonStage = false;
            tileManager.bossStage = true;
            /* if(BossBehavior.isDead == true)                        // **Change** to IF boss dead stop StageBoss go to normal stage
            {
                CloseBoss();
            }*/
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
        TrapPlatform.gateSpawn = false;
    }

    #endregion

}

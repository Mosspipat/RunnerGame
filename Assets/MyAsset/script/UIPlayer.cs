using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour {

    ScoreManagerAndEvent TSscoreGame;
    playerController PCstatusPlayer;

    float score = 0;                                            //score Run
    public int intergerScore{ set; get;}
    public Text scoreText;

    float scoreCoin = 0;                                            //score coins
    public Image coinImageUI;
    public int intergerScoreCoin{ set; get;}
    public Text scoreTextCoin;

    public static Vector2 sizeCoinImage;

    public static int countStageDungeon;

    public Image miniMap;
    public Image playerImage;
    float distantStartAndEnd;
    public Transform startPosMinimap;
    public Transform endPosMinimap;
    float mapLengthMax = 50;

    public enum Stages
    {
        normal,
        dungeon
    };

    void Start () {
        distantStartAndEnd = Vector2.Distance(startPosMinimap.position, endPosMinimap.position);
        Debug.Log("distand between start and end Point :" + distantStartAndEnd);

        sizeCoinImage = new Vector2(10f, 10f);
        score = 0;
        playerImage.transform.position = startPosMinimap.transform.position;
    }
    
    /*void FixedUpdate()
    {
        this.transform.position = new Vector3(player.transform.position.x+3f,player.transform.position.y+2.5f,player.transform.position.z);
        this.transform.localScale = new Vector3(-0.05f ,0.05f, 0.05f);
        this.transform.LookAt(Camera.main.transform);
    }*/

    void Update () {
        coinImageUI.rectTransform.sizeDelta =  Vector2.Lerp( new Vector2(coinImageUI.rectTransform.sizeDelta.x
            ,coinImageUI.rectTransform.sizeDelta.y) ,
            sizeCoinImage,0.7f);                                    //lerp starter Image coin Size
        
        scoreText.text = intergerScore.ToString()+" mile";
        RunScore();
        CoinScore();
        EventGameplay();
        Minimap();

        CheckReleaseDungeon(3);
    }

    #region Run
    void RunScore()
    {
        /*score += 1 * Time.deltaTime;*/
        score = GameObject.Find("player").transform.GetComponent<Transform>().position.z;
        intergerScore = (int)score / 1;
    }
    #endregion

    #region coins
    void CoinScore()
    {
        scoreTextCoin.text = "x " + intergerScoreCoin.ToString();
    }
    #endregion

    #region SpecialEvent
    void EventGameplay()
    {
        if (intergerScore %200 == 0 && intergerScore !=0 && tileManager.bossStage == false)       //Bonus Stage and will not start gameplay's starter
        {                                                                                       // check it boss stage will not spawn Dungeon Stage
            Debug.Log("open Dungeon");
            TrapPlatform.canGateSpawn = true;
            tileManager.dungeonStage = true;
        }

        if (intergerScore %300 == 0 && intergerScore !=0 && tileManager.dungeonStage == false)       //Bonus Stage and will not start gameplay's starter
        {
            Debug.Log("open boss stage");
            tileManager.dungeonStage = false;
            tileManager.bossStage = true;
            /* if(BossBehavior.isDead == true)                        // **Change** to IF boss dead stop StageBoss go to normal stage
            {
                CloseBoss();
            }*/
        }
        if (intergerScore % 100 == 0 && intergerScore !=0)
        {
            Time.timeScale += 0.02f;
        }
    }

    void CheckReleaseDungeon (int countDungeonStage )
    {
        if (countStageDungeon == countDungeonStage)
        {
            CloseDungeon();
        }
    }

    void CloseDungeon()
    {
        tileManager.dungeonStage = false;
        TrapPlatform.gateSpawn = true;
        countStageDungeon = 0;
    }

    void CloseBoss()
    {
        tileManager.dungeonStage = false;
        TrapPlatform.gateSpawn = false;
    }
    #endregion

    #region miniMap And CheckQuest
    void Minimap()
    {
        float calDistanceMinimapMax = distantStartAndEnd;
        float calDistanceMinimap = (intergerScore / mapLengthMax) * distantStartAndEnd; 
        if (calDistanceMinimap >= distantStartAndEnd)                                       //Check if miniPlayer has "finished distance" Stop miniplayer
        {
            calDistanceMinimap = distantStartAndEnd;
            intergerScore = (int)mapLengthMax;
            tileManager.QuestStage = true;
        }
        Vector3 distanceMinimap = new Vector3( calDistanceMinimap,0,0);
        Debug.Log("calDistanceMinimap" + calDistanceMinimap + " and " + "mapLengthMax" + mapLengthMax);
        playerImage.transform.position = startPosMinimap.transform.position + distanceMinimap;            //player distance in Minimap
        miniMap.fillAmount = 1f;
    }
    #endregion
}
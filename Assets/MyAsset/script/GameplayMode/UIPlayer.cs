using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour {

    ScoreManagerAndEvent TSscoreGame;
    playerController PCstatusPlayer;

    float score = 0;                                            //score Run
    public static int intergerScore;
    public Text scoreText;

    public static int amountMonsterKilled;

    public Image coinImageUI;
    public static int intergerScoreCoin{ set; get;}
    public Text scoreTextCoin;

    public static Vector2 sizeCoinImage;

    public static int countStageDungeon;

    /*public Image miniMap;*/
    public Image playerImage;

    float distantStartAndEnd;
    public Transform startPosMinimap;
    public Transform endPosMinimap;
    float mapLengthMax = 100;                //Max Range Map
    public static float distancePlayermake;

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
        //Event DungeonApprea
        if (tileManager.amountSpawnedPlatform % 20 == 0 && tileManager.bossStage == false)       //Bonus Stage and will not start gameplay's starter
        {                                                                                       // check it boss stage will not spawn Dungeon Stage
            Debug.Log("open Dungeon");

            //spawn " Gate " at firstDungeon
            TrapPlatform.canGateSpawn = true;  

            //stage " Dungeon is true"
            tileManager.dungeonStage = true;
            tileManager.amountDungeonCanSpawn = 5; // set amount stage Can Spawn dungeon
        }
        //Event BossApprea
        if (tileManager.amountSpawnedPlatform == 300 && tileManager.dungeonStage == false)       //Bonus Stage and will not start gameplay's starter
        {
            Debug.Log("open boss stage");
            // close Dungeon stage
            /* tileManager.dungeonStage = false;*/

            tileManager.bossStage = true;
            /* if(BossBehavior.isDead == true)                        // **Change** to IF boss dead stop StageBoss go to normal stage
            {
                CloseBoss();
            }*/
        }
        //Speed up with more Score
        if (intergerScore % 100 == 0 && intergerScore !=0)
        {
            Time.timeScale += 0.02f;
        }
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

            //Check QuestComplete
            tileManager.questDistance = true;  
        }
        Vector3 distanceMinimap = new Vector3( calDistanceMinimap,0,0);
        playerImage.transform.position = startPosMinimap.transform.position + distanceMinimap;            //player distance in Minimap
        /*miniMap.fillAmount = 1f;*/        //Error Check
    }
    #endregion
}
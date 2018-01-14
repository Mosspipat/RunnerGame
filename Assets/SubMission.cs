using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMission : MonoBehaviour {

    int serialMission = 1;

    Text TextQuest;
    public GameObject trueSymbol;

    string monsterName;
    int amountMonster;

    string orderMonsterHunt;
    int orderAmountHunt;

    int originalMision;
    int HuntedMonster;

    public int b;

    void Start () {
        //SerialMission();
        TextQuest = GameObject.Find("textQuest").GetComponent<Text>();
        Debug.Log("serialMission :" + PlayerPrefs.GetInt(serialMission + "Quest"));
        if (PlayerPrefs.GetInt(serialMission + "Quest") == 0)
        {
            RandomMission();
            ShowOriginMission();
            Debug.Log("random mission");
            PlayerPrefs.SetInt(serialMission + "Quest", 1);
        }
        else if (PlayerPrefs.GetInt(serialMission + "Quest") == 1)
        {
            Debug.Log("have Quest");
            ShowOriginMission();
        }

        //Check form last Mission Save
        string nameCommand = PlayerPrefs.GetString("Quest" + serialMission + "MonsterName");
        int amountCommand = PlayerPrefs.GetInt("Quest" + serialMission + "AmountMonster");
        PlayerPrefs.SetInt(nameCommand+"Hunted",b);
        HuntedMonster = PlayerPrefs.GetInt(nameCommand+"Hunted");


        if (HuntedMonster >= amountCommand)
        {
            Debug.Log(amountCommand + "\n" + HuntedMonster);
            trueSymbol.SetActive(true);
            Debug.Log("Can Complete");
        }
    }

    public void PressToCompleteMission()
    {
        if (HuntedMonster >= originalMision)
        {
            Debug.Log("doneQuest");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("QuestNotComplete");
        }
    }

    void RandomMission()
    {
        monsterName = RandomMonsterToHunt(1, 6);
        PlayerPrefs.SetString("Quest" + serialMission + "MonsterName", monsterName);
        amountMonster = RandomMonsterAmountToHunt(1, 3);
        PlayerPrefs.SetInt("Quest" + serialMission + "AmountMonster", amountMonster);
        Debug.Log( "random is :" +monsterName + "\n amount :" + amountMonster);
    }

    string RandomMonsterToHunt(int monsterStart,int monsterEnd)
    {
        int monsterRandom = Random.Range(monsterStart, monsterEnd + 1);
        switch (monsterRandom)
        {
            case 1:
                monsterName = "rabbit";
                PlayerPrefs.SetInt("expRabbit", 2);
                break;
            case 2:
                monsterName = "slime";
                PlayerPrefs.SetInt("expSlime", 3);
                break;
            case 3:
                monsterName = "bat";
                PlayerPrefs.SetInt("expBat", 5);
                break;
            case 4:
                monsterName = "ghost";
                PlayerPrefs.SetInt("expGhost", 10);
                break;
            case 5:
                monsterName = "fireMonster";
                PlayerPrefs.SetInt("expfireMonster", 30);
                break;
            case 6:
                monsterName = "skeleton";
                PlayerPrefs.SetInt("expSkeleton", 50);
                break;
        }
        return monsterName;
    }
    int RandomMonsterAmountToHunt(int min, int max)
    {
        int amount = Random.Range(min, max + 1);
        switch (amount)
        {
            case 1:
                amountMonster = 1;
                break;
            case 2:
                amountMonster = 2;
                break;
            case 3:
                amountMonster = 3;
                break;
        }
        return amountMonster;
    }

    #region CheckMission()
    void ShowOriginMission()
    {
        TextQuest.text = "Quest hunt : " + PlayerPrefs.GetString("Quest" + serialMission + "MonsterName") + "\n amount : " + PlayerPrefs.GetInt("Quest" + serialMission + "AmountMonster"); 
    }
    #endregion
    #region makeSerialMission
    void SerialMission()
    {
        serialMission = PlayerPrefs.GetInt("serialMission");
        int nextSeiralMission =  serialMission+1;
        PlayerPrefs.SetInt("serialMission", nextSeiralMission);
        Debug.Log(PlayerPrefs.GetInt("serialMission"));
    }
    #endregion
}
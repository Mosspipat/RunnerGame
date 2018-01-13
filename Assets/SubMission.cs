using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMission : MonoBehaviour {

    Text TextQuest;
    public GameObject trueSymbol;

    public int NumQuest;
    bool isComplete = true;

    string monsterName;
    int amountMonster;

    string orderMonsterHunt;
    int orderAmountHunt;

    int originalMision;
    int HuntedMonster;

    public int b;

	void Start () {
        RandomMission();
        TextQuest = GameObject.Find("textQuest").GetComponent<Text>();

        orderMonsterHunt = PlayerPrefs.GetString("Quest" + NumQuest + monsterName);
        orderAmountHunt = PlayerPrefs.GetInt("Quest"+NumQuest+"haveToHunt"+amountMonster);
        PlayerPrefs.SetInt(monsterName + "Hunted", b);
       
        originalMision = PlayerPrefs.GetInt("Quest" + NumQuest + orderMonsterHunt + "haveToHunt" + orderAmountHunt);
        Debug.Log("Quest have is :" + originalMision);

        TextQuest.text = "Quest hunt : " + orderMonsterHunt + "\n amount : " + orderAmountHunt; 
        HuntedMonster = PlayerPrefs.GetInt(monsterName + "Hunted");

        if (HuntedMonster >= originalMision)
        {
            trueSymbol.SetActive(true);
            Debug.Log("Can Complete");
        }
    }
    
    public void PressToCompleteMission()
    {
        if (HuntedMonster >= originalMision)
            {
                Debug.Log(originalMision + "\n" + PlayerPrefs.GetInt(monsterName + "Hunted"));
                Debug.Log("doneQuest");
                RandomMission();
            }
            else
            {
            Debug.Log("must have" + originalMision + "\n you have :" +HuntedMonster);
                Debug.Log("QuestNotComplete");
            }
    }

    void RandomMission()
    {
        monsterName = RandomMonsterToHunt(1, 6);
        PlayerPrefs.SetString("Quest" + NumQuest + monsterName,monsterName);
        amountMonster = RandomMonsterAmountToHunt(1, 3);
        PlayerPrefs.SetInt("Quest"+NumQuest+"haveToHunt"+amountMonster,amountMonster);
        Debug.Log(PlayerPrefs.GetInt("Quest"+NumQuest+"haveToHunt"+amountMonster,amountMonster));

        PlayerPrefs.SetInt("Quest" + NumQuest + monsterName + "haveToHunt" + amountMonster,amountMonster);
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
         
}

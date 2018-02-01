using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class SelectionScene : MonoBehaviour {

    public GameObject LoadBackgroud;
    public Slider loadbar;
    public Text percentLoaded;


    int levelPlayer;
    public List<GameObject> UIUnlock;
    public List<Text> textStage;

    int expPlayer;


    void Start()
    {
        levelPlayer = PlayerPrefs.GetInt("levelPlayer");
    }

    void Update()
    {   //control ExpPlayer
        LevelUP();
        UnlockStage();
    }

    public void GoToLevelGreenField()
    {
        LoadLevel("GameplayGreenField");
    }

    public void GoToLevelBlackForest()
    {

        LoadLevel("GameplayBlackForest");
        //Application.LoadLevel("GameplayBlackForest");
    }

    public void GoToLevelRedVolcano()
    {
        //LoadAsynchronously("");
    }

    public void GoToItemShop()
    {
        LoadLevel("ShopUpgrade");
        //Application.LoadLevel("ShopUpgrade");
    }

    public void GoToWeaponShop()
    {
        LoadLevel("shopWeapon");
    }

    public void LoadLevel(string nameLevel)
    {
        StartCoroutine(LoadAsynchronously(nameLevel));
    }

    void LevelUP()
    {
        expPlayer = PlayerPrefs.GetInt("expPlayer");
        int maxExpPlayer = 10 * (int)(Mathf.Pow(2, PlayerPrefs.GetInt("levelPlayer") - 1)); 

        if (levelPlayer >= 5 && expPlayer >= maxExpPlayer)
        {
            expPlayer = maxExpPlayer;
            PlayerPrefs.SetInt("levelPlayer",levelPlayer);
            PlayerPrefs.SetInt("expPlayer", expPlayer);
        }
        else if (expPlayer >= maxExpPlayer)
        {
            levelPlayer++;
            PlayerPrefs.SetInt("levelPlayer",levelPlayer);
            PlayerPrefs.SetInt("expPlayer", 0);
        }
    }

    void UnlockStage()
    {
        for (int i = 0; i < 6; i++)
        {
            if (levelPlayer >= i)
            {
                UIUnlock[i].SetActive(false); 
                continue;
            }
            else
            {
                UIUnlock[i].SetActive(true); 
            }
        }

        for (int i = 0; i < 6; i++)
        {
            textStage[i].text = "need Level " + i; 
        }
    }

    IEnumerator LoadAsynchronously(string nameLevel)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameLevel);
        LoadBackgroud.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadbar.value = progress;
            percentLoaded.text = (progress*100f).ToString() + " %";
            Debug.Log(progress);

            yield return null;
        }
    }


    //playerPrefs.int(levelPlayer)
    //playerPrefs.int(expPlayer)
}

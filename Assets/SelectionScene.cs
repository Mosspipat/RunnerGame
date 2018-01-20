using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class SelectionScene : MonoBehaviour {

    public GameObject LoadBackgroud;
    public Slider loadbar;
    public Text percentLoaded;


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
}

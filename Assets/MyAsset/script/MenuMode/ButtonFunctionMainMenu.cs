using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctionMainMenu : MonoBehaviour {

    bool CheckFullScreen; 

    void Start()
    {
        CheckFullScreen = Screen.fullScreen;
            
        switch (CheckFullScreen)
        {
            case true:
                PlayerPrefs.SetString("isFullScreen", "true");
                break;
            case false:
                PlayerPrefs.SetString("isFullScreen", "false");
                break;
        }
    }

    public void GoSceneGameplay()
    {
        Application.LoadLevel("menuMap");
    }

    public void GoSceneOption()
    {
        Application.LoadLevel("optionSetting");
    }

    public void GoEndlessGameplay()
    {
        Application.LoadLevel("gameplay");
    }
}

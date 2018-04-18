using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public Toggle ToggleisFullScreen;
    bool isFullScreen;

    void Start()
    {
        string checkFullScreen = PlayerPrefs.GetString("isFullScreen");
        switch (checkFullScreen)
        {
            case "true":
                isFullScreen = true;
                break;
            case "false":
                isFullScreen = false;
                break;
        }
        ToggleisFullScreen.isOn = isFullScreen;
    }

    public void SetVolume(float volum)
    {
        audioMixer.SetFloat("volume",volum);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex.ToString());
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (isFullScreen)
        {
            PlayerPrefs.SetString("isFullScreen", "true");
        }
        else
        {
            PlayerPrefs.SetString("isFullScreen", "false");
        }
        Debug.Log(isFullScreen);
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel("menuStart");
    }

}

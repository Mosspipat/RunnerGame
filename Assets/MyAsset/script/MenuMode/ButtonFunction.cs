using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour {


    public void GoSceneGameplay()
    {
        Application.LoadLevel("gameplay");
    }

    public void GoSceneOption()
    {
        Application.LoadLevel("option");
    }

    public void GoSceneCharacter()
    {
        Application.LoadLevel("profile");
    }

}

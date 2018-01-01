using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour {


    public void GoSceneGameplay()
    {
        Application.LoadLevel("menuMap");
    }

    public void GoSceneOption()
    {
        Application.LoadLevel("option");
    }

    public void GoEndlessGameplay()
    {
        Application.LoadLevel("gameplay");
    }

}

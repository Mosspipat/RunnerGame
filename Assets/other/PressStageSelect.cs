using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStageSelect : MonoBehaviour {

    SelectionScene selectScene;
    public int stage;
    public int lengthMap;

	void Start () {
        selectScene = GameObject.Find("SceneSelectManager").GetComponent<SelectionScene>();
	}

    public void SendStage()
    {
        selectScene.stageSeleted = stage;
        selectScene.GoToLevelGreenField();


        //sendLenghtMap
        UIPlayer.mapLengthMax = lengthMap;
    }
}

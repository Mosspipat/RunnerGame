using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStageSelect : MonoBehaviour {

    SelectionScene selectScene;
    public int stage;

	void Start () {
        selectScene = GameObject.Find("SceneSelectManager").GetComponent<SelectionScene>();
	}

    public void SendStage()
    {
        selectScene.stageSeleted = stage;
        selectScene.GoToLevelGreenField();
    }
}

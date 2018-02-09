using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    int stage;
    AudioSource soundManager;
    public List<AudioClip> soundStore;

    SelectionScene selectScene;

	void Start () {

        selectScene = GameObject.Find("SceneSelectManager").GetComponent<SelectionScene>();
        stage = selectScene.stageSeleted;

        soundManager = GetComponent<AudioSource>();
        soundManager.loop = true;
        PlaySoundStage();

    }
    
    void Update () {
        
    }

     void PlaySoundStage()
    {
        switch (stage)
        {
            case 1 : case 2:
                soundManager.clip = soundStore[0];
                soundManager.Play();
                break;
            case 3 : case 4:
                soundManager.clip = soundStore[1];
                soundManager.Play();
                break;
            case 5 : case 6:
                soundManager.clip = soundStore[2];
                soundManager.Play();
                break;
        }
    }

}

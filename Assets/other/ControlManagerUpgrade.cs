using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManagerUpgrade : MonoBehaviour {

    public List<AudioClip> soundStore;
    AudioSource soundManager;

    public Transform positionToMove;
    public Transform positionUpgradePanel;

    public int startPosition = 0;
	
    void Start()
    {
        soundManager = GetComponent<AudioSource>();
    }

	void Update () {
        positionUpgradePanel.transform.position = Vector3.Lerp(positionUpgradePanel.transform.position,positionToMove.GetChild(startPosition).transform.position,1f*Time.deltaTime);
	}

    public void Next()
    {
        soundManager.PlayOneShot(soundStore[0]);
        startPosition += 1;
        if (startPosition > 3)
        {
            startPosition = 0;
        }
    }

    public void Previous()
    {
        soundManager.PlayOneShot(soundStore[0]);
        startPosition -= 1;
        if (startPosition < 0)
        {
            startPosition = 3;
        }
    }

    public void BackToMapSelection()
    {
        soundManager.PlayOneShot(soundStore[1]);
        Application.LoadLevel("menuMap");
    }
}

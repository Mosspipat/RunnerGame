using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEnemyBehavior : MonoBehaviour {

    AudioSource soundManager;
    public List<AudioClip> soundStore;

	void Start () {
        soundManager = GetComponent<AudioSource>();
	}
	
    public void ShootSoundTrigger()
    {
        soundManager.PlayOneShot(soundStore[1]);
    }

    public void MelleSoundTrigger()
    {
        soundManager.PlayOneShot(soundStore[0]);
    }
}

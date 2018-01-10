using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrevious : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void BackToMenu()
    {
        Application.LoadLevel("menuMap");
    }
}

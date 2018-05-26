using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour {

    public enum TypeTrap
    {
        wall,
        floor,
        roof 
    };

    public TypeTrap Trap;
    string nameOfTypeAnimation;

	void Start () {

        switch (Trap)
        {
            case TypeTrap.wall: nameOfTypeAnimation = "actionTrapWall";
                this.GetComponent<Animation>()[nameOfTypeAnimation].speed = 0.2f;//0.3                  //set this to Speed up/Speed down Animation;
                break;
            case TypeTrap.floor: nameOfTypeAnimation = "actionTrapFloor";
                this.GetComponent<Animation>()[nameOfTypeAnimation].speed = 0.3f;//0.5
                break;
            case TypeTrap.roof: nameOfTypeAnimation = "actionTrapRoof";
                this.GetComponent<Animation>()[nameOfTypeAnimation].speed = 0.1f;//0.2
                break;
        }
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

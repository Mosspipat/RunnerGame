using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnBehavior : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        ItemRotate();
	}
    #region Items Behavior 
    void ItemRotate()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime*100f);
    }

    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "player")
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

}

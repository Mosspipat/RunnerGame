using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour {

    public string moveDirectionTo{ get; set;}
    Randomcloud checkCloud; 
    RectTransform PosCloud;

	void Update () {
        checkCloud = GameObject.Find("cloudSpawnSystem").transform.GetComponent<Randomcloud>();
        PosCloud = GetComponent<RectTransform>();
        MoveAndDestroyItSelf();
        DestroyitSelf();
	}

    void MoveAndDestroyItSelf()
    {
        if (moveDirectionTo == "moveToRight")
        {
            this.transform.Translate(30f * Time.deltaTime, 0, 0);
        }
        else if (moveDirectionTo == "moveToLeft")
        {
            this.transform.Translate(-30f * Time.deltaTime, 0, 0);
        }
    }
    void DestroyitSelf()
    {
        if(PosCloud.localPosition.x > 1300 || PosCloud.localPosition.x < -1300)
        {
            Destroy(this.gameObject);
            checkCloud.numCloud--;
        }
    }
}

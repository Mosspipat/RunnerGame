using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBox : MonoBehaviour {

    bool canRoot = true;
    bool isSpawn = true;

    Animator animBox;
    CraftItem ci;

	void Start () {
        ci = GameObject.Find("posionPot").GetComponent<CraftItem>();

        Debug.Log("start RootBox");
        animBox = this.GetComponent<Animator>();
	}
	
	void Update () {
        if (animBox.GetCurrentAnimatorStateInfo(0).IsName("open") && isSpawn == true)
        {
            SpawnIngredients(3);
            isSpawn =! isSpawn;
        }
    }

    public void OnMouseDown()
    {
        if (canRoot)
        {
            animBox.SetTrigger("isOpen");
            isSpawn = true;

            canRoot = false;                                         
            Invoke("CanPressRootBoxAgain", 3f);                 //can root box Again 
        }
    }

    #region spwanItem
    void SpawnIngredients(int numOfSpawn)
    {
        for (int countRan = 0; countRan < numOfSpawn; countRan++)
        {
            int randomItem = Random.Range(0,ci.ingredients.Count);
            float randomSpwanX = Random.Range(-1f, 1f);
            GameObject nameItemSpawn =  Instantiate(ci.ingredients[randomItem],this.transform.position+ Vector3.up *1f+Vector3.forward*randomSpwanX,Quaternion.identity);
            nameItemSpawn.name = ci.ingredients[randomItem].name;
        }
    }

    void CanPressRootBoxAgain()
    {
        canRoot = true;
    }
    #endregion
}

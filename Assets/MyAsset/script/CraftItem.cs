using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour {

    public GameObject SampleLeaf;
    public List<GameObject> ingredients = new List<GameObject>();               //save all Ingredients in game

    public List<string> craftSlot = new List<string>();                 //get ingredient from BookIngredient to craft

    [HideInInspector]
    public int slotCraftNum = 0;


    [HideInInspector]
    public List<string> inGredientToCraft = new List<string>();

    public Text nameItem;

	void Start () {

        /*foreach (GameObject allIngre in ingredients)              //Check start ingredient 
        {
            Debug.Log(allIngre.name);
        }*/

        for (int i = 0; i < 2; i++)
        {
            craftSlot.Add("start");
        }
        /*Craft();
        nameItem.text = nameItemCrafted ;*/
	}

    public void Craft()
    {
        
    }
}

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

        nameItem = GameObject.Find("plateItemName").transform.GetChild(0).GetChild(0).GetComponent<Text>();

        foreach (GameObject allIngre in ingredients)
        {
            Debug.Log(allIngre.name);
        }

        for (int i = 0; i < 2; i++)
        {
            craftSlot.Add("start");
        }
        /*Craft();
        nameItem.text = nameItemCrafted ;*/
	}

    public void Craft()
    {
        if(inGredientToCraft[0]=="botton"&&inGredientToCraft[1]=="fruit")
        {
            Debug.Log("posion item Create");
        }
        else if(inGredientToCraft[0]=="botton"&&inGredientToCraft[1]=="leaf")
        {
            Debug.Log("speed item Create");
        }
        else if(inGredientToCraft[0]=="wood"&&inGredientToCraft[1]=="wood")
        {
            Debug.Log("shield item Create");
        }
        else if(inGredientToCraft[0]=="wood"&&inGredientToCraft[1]=="plate")
        {
            Debug.Log("knife item Create");
        }
    }
}

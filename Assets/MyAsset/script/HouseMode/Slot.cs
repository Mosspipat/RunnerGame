using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    CraftItem CI ;
    bookIngredient BI;
    public int numSlot;
    Image imageSlot;

    string nameIngreInSlot;

    public Transform craftSlot;

    public bool CheckInventoryItems = false;

	void Start () {
        BI = GameObject.Find("book").GetComponent<bookIngredient>();
        CI = GameObject.Find("posionPot").GetComponent<CraftItem>();
        imageSlot = this.GetComponent<Image>();
    }
    
    void Update () {
        if (CheckInventoryItems == true)
        {
            imageSlot.sprite = Resources.Load("Ingredients/" + BI.inventory[numSlot], typeof(Sprite)) as Sprite;
            nameIngreInSlot = BI.inventory[numSlot];
        }
        else
        {
            imageSlot.sprite = null;
        }
    }

    #region ChangeIngredientsToCraft
    public void ChooseIngredients()
    {
        if (CI.slotCraftNum < 2 && BI.inventory[numSlot] != "empty")        //check that's slot will can be fill in And not "empty" 
        {
            CI.craftSlot[CI.slotCraftNum] = BI.inventory[numSlot];          // get Ingredient's name to SlotCraft
            BI.inventory[numSlot] = "empty";                                // make Ingredient's name Empty
            foreach(Transform craftImage in craftSlot)
            {
                if (craftImage.GetComponent<Image>().sprite.name == "start")
                {
                    craftImage.GetComponent<Image>().sprite = Resources.Load("Ingredients/" + CI.craftSlot[CI.slotCraftNum], typeof(Sprite)) as Sprite;
                    CI.slotCraftNum++;
                    Debug.Log(CI.slotCraftNum);
                    break;
                }
                else
                {
                    Debug.Log("Input new SlotCraft");
                }
            }
        }
    }
    #endregion
}

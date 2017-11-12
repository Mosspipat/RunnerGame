using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour {

    bookIngredient BI;
    CraftItem CI;
    string nameItem;

    public int NumSlotCraft;

    void Start () {
        BI = GameObject.Find("book").GetComponent<bookIngredient>();
        CI = GameObject.Find("posionPot").GetComponent<CraftItem>();
	}

    public void Deselect()
    {
        if (CI.slotCraftNum < 1)
        {
            return;
        }

        else if(CI.craftSlot[NumSlotCraft] != "start")              //Check if craftSlot is "Start" can not send back to Inventory
        {
            Debug.Log("deSelect");
            for(int slotNum = 0;slotNum <16 ;slotNum++)                             //move Ingredients's name To inventory ***same Ingredient to Inventory**
            {
                if (BI.inventory[slotNum] == "empty")
                {
                    BI.inventory[slotNum] = CI.craftSlot[NumSlotCraft];
                    break;
                }
            }
            CI.craftSlot[NumSlotCraft] = "start";                           //make index of slotCraft back to start
            this.GetComponent<Image>().sprite = Resources.Load("Ingredients/" + CI.craftSlot[NumSlotCraft], typeof(Sprite)) as Sprite;  // bring slotCraft

            CI.slotCraftNum--;      
        }
    }

}

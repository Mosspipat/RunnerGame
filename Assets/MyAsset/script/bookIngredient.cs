using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bookIngredient : MonoBehaviour {

    public List<string> inventory = new List<string>();  

    public List<Transform> point = new List<Transform>();
    bool isOpen = false;

    public Transform CheckerAllSlot;

    Animator animBook;
    CraftItem CI;

    public Transform mainSlotCraft;

    public GameObject boxItemSpawn;

    public static string itemName;

	void Start () {
        
        CI = GameObject.Find("posionPot").GetComponent<CraftItem>();
        animBook = GetComponent<Animator>();
        this.transform.position = point[0].position;

        for (int i = 0; i < 16; i++)
        {
            inventory.Add("empty");
        }
	}
	
	void Update () {
        OpenAndCloseBook();
	}

    #region Open Book && CloseToCraft Book
    public void OpenAndCloseBook()
    {
        if (isOpen == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, point[1].position, 2f * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, point[0].position, 1f * Time.deltaTime);
        }
    }

    public void SetOpen()
    {
        isOpen = true;
        animBook.SetTrigger("isOpen");

        foreach (Transform allSlot in CheckerAllSlot)
        {
            allSlot.GetComponent<Slot>().CheckInventoryItems = true;
        }
    }

    public void SetCloseAndCraft()
    {
        
        isOpen =! isOpen;
        animBook.SetTrigger("isClose");

        if (ShelfItems.numberEmptySlot > 5 )
        {
            return;
        }

        else if (CI.craftSlot[0] == "botton" && CI.craftSlot[1] == "cherry" || CI.craftSlot[0] == "cherry" && CI.craftSlot[1] == "botton")
        {
            Debug.Log("Create posion");
            itemName = "redPosion";
        }
        else if (CI.craftSlot[0] == "botton" && CI.craftSlot[1] == "leaf" || CI.craftSlot[0] == "leaf" && CI.craftSlot[1] == "botton")
        {
            Debug.Log("Create speed");
            itemName = "greenPosion";

        }
        else if (CI.craftSlot[0] == "wood" && CI.craftSlot[1] == "wood")
        {
            Debug.Log("Create shield");
            itemName = "shield";

        }
        else if (CI.craftSlot[0] == "iron" && CI.craftSlot[1] == "blade" || CI.craftSlot[0] == "blade" && CI.craftSlot[1] == "iron")
        {
            Debug.Log("Create axe");
            itemName = "axe";

        }
        else if (CI.craftSlot[1] == "start")      //check not insert any ingredient Or insert 1 ingredient in slot 
        {
            Debug.Log("nothing");
            return;
        }
        else
        {
            Debug.Log("have ingre in CraftSlot :" + CI.craftSlot.Count);
            Debug.Log("fail Create");
            itemName = "expReward";

            Debug.Log(CI.craftSlot[0]);
            Debug.Log(CI.craftSlot[1]);
        }

        foreach (Transform ingreSlot in mainSlotCraft)
        {
            ingreSlot.GetComponent<Image>().sprite = Resources.Load("Ingredients/start", typeof(Sprite)) as Sprite;
        }

        for ( int smallCraftslot = 0 ; smallCraftslot < CI.craftSlot.Count; smallCraftslot ++)
        {
            CI.craftSlot[smallCraftslot] = "start";
        }

        CI.slotCraftNum = 0;
        SpawnSampleItem();
    }



    void SpawnSampleItem()
    {
        GameObject SampleItem = Instantiate(boxItemSpawn);
    }
    #endregion
}

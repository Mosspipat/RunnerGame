using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfItems : MonoBehaviour {

    public static List<string> itemsCollection = new List<string>();
    public static List<string> itemPosOnShelf = new List<string>();
    public static bool updateSlotInsert = false;   // Set to false
    public static int numberEmptySlot = 0;   
    public Transform Shelf;

	void Start () {
        for(int slotShelf = 0 ; slotShelf < Shelf.childCount;slotShelf++)
        {
            itemsCollection.Add("empty");       //set empty
            itemPosOnShelf.Add("empty");         //set empty
        }

    }
    
    void Update () {
        OnShowItemsOnShelf();
	}


    #region ShowItemsOnShelf
    void OnShowItemsOnShelf()
    {
        for(int slotShelf = 0 ; slotShelf < Shelf.childCount;slotShelf++)
        {
            if (itemPosOnShelf[slotShelf] == "empty"&& updateSlotInsert == true)
            {
                Debug.Log("name find : " + "TextItem"+slotShelf);
                GameObject.Find("TextItem"+slotShelf).GetComponent<Text>().text = itemsCollection[slotShelf];
                GameObject.Find("ImageItem"+slotShelf).GetComponent<Image>().sprite = Resources.Load("items/" + itemsCollection[slotShelf], typeof(Sprite)) as Sprite;

                itemPosOnShelf[slotShelf] = "full";
                updateSlotInsert = false;
                numberEmptySlot++;
                break;
            }
        }
    }
    #endregion
}

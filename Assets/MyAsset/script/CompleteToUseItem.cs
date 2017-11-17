using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteToUseItem : MonoBehaviour {

    public int numBoxItem;

    void OnMouseDown()
    {
        if (ShelfItems.itemsCollection[numBoxItem] != "empty")
        {
            Debug.Log("Use item");
            ShelfItems.itemsCollection[numBoxItem] = "empty";
            ShelfItems.itemPosOnShelf[numBoxItem] = "empty";

            GameObject.Find("TextItem"+numBoxItem).GetComponent<Text>().text = "";
            GameObject.Find("ImageItem"+numBoxItem).GetComponent<Image>().sprite =  Resources.Load("items/questionItem", typeof(Sprite)) as Sprite;
            ShelfItems.numberEmptySlot--;
        }
    }
}

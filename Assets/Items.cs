using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour {

    public GameObject startPoint;
    public GameObject endPoint;

    public Image imageItem;
    public Text nameItem ;

	void Start () {
       
        imageItem = GameObject.Find("imageItem").GetComponent<Image>();
        nameItem = GameObject.Find("nameItem").GetComponent<Text>();
        ImageAndName();

        this.transform.position = startPoint.transform.position;
    }

    void Update()
    {
        MovePoint();
    }

    #region StartPosition
    void MovePoint()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,endPoint.transform.position,2f *Time.deltaTime);
    }
    #endregion

    #region ImageAndName && behavior
    void ImageAndName()
    {
        imageItem.sprite = Resources.Load("items/" + bookIngredient.itemName, typeof(Sprite)) as Sprite;
        nameItem.text = bookIngredient.itemName;

        ShelfItems.itemsCollection[ShelfItems.numberEmptySlot] = bookIngredient.itemName;
        ShelfItems.updateSlotInsert = true;
        Destroy(this.gameObject, 1f);
    }
    #endregion
}

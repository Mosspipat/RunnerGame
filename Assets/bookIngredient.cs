using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bookIngredient : MonoBehaviour {

    public List<string> inventory = new List<string>();  

    public List<Transform> point = new List<Transform>();
    bool isOpen = false;

    public Transform CheckerAllSlot;

    Animator animBook;

	void Start () {
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

    #region OpenBookAndCloseBook
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

    public void SetClose()
    {
        isOpen =! isOpen;
        animBook.SetTrigger("isClose");
    }
    #endregion
}

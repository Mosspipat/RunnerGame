using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

    public float forceStart;

    bookIngredient BI;

	void Start () {
        BI = GameObject.Find("book").GetComponent<bookIngredient>();
        StartSpwan();
	}
	
	void Update () {
        this.transform.Rotate(new Vector3(0,100f *Time.deltaTime,0));
	}

    public void OnMouseDown()
    {
        for(int slotNum = 0;slotNum <16 ;slotNum++)
        {
            if (BI.inventory[slotNum] == "empty")
            {
                BI.inventory.RemoveAt(slotNum);
                BI.inventory.Insert(slotNum,this.gameObject.name);
                Destroy(this.gameObject);

                break;
            }
        }

        Debug.Log("add "+this.gameObject.name +" to Ingredients");
        /*Debug.Log("****************");

        int num = 0;
        foreach (string allIngre in BI.inventory)
        {
            Debug.Log("have " + allIngre +  "in" + num);
            num++;
        }
        Debug.Log("****************");*/
    }

    void StartSpwan()
    {
        float randomforce = Random.Range(-100,100); 

        if (this.tag == "ingredient")
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(randomforce,350f,0));
        }
    }
}

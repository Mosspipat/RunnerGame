using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPurchase : MonoBehaviour {

    public string sendTo;
    public Button purchaseButton;  
    public int price;

    public Text amouthaveText;
    int amoutHave;

	void Start () {
        purchaseButton.onClick.AddListener(PurchaseItem);
    }
    
    void Update () {
        transform.Find("buttonPurchaseItem/Text").transform.GetComponent<Text>().text =  price + " Coins";
        transform.Find("haveText").transform.GetComponent<Text>().text = "you have :" + amoutHave;
	}

    #region Purchase
    void PurchaseItem()
    {
        if (CharacterStatus.coinsWallet >= price)
        {
            amoutHave++;
            CharacterStatus.isPurchaseOrUpgrade = true;
            CharacterStatus.itemPurchaseOrUpgrade = sendTo;
            CharacterStatus.coinsWallet -= price;
        }
    }
    #endregion
}

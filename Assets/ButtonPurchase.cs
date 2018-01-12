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
        amoutHave = PlayerPrefs.GetInt(sendTo + "Have");
    }
    
    void Update () {
        transform.Find("buttonPurchaseItem/Text").transform.GetComponent<Text>().text =  price + " Coins";
        transform.Find("haveText").transform.GetComponent<Text>().text = "You have : "+PlayerPrefs.GetInt(sendTo+"Have").ToString();
	}

    #region Purchase
    void PurchaseItem()
    {
        if ( PlayerPrefs.GetInt("money") >= price)
        {
            amoutHave++;
            /*CharacterStatus.isPurchaseOrUpgrade = true;
            CharacterStatus.itemPurchaseOrUpgrade = sendTo;*/
            int moneyShop = PlayerPrefs.GetInt("money");
            moneyShop -= price;
            PlayerPrefs.SetInt("money",moneyShop);
            PlayerPrefs.SetInt(sendTo + "Have", amoutHave);
        }
    }
    #endregion
}

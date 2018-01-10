using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrade : MonoBehaviour {

    public string sendTo;
    public Button purchaseButton;  
    public GameObject point;
    public int price;

    int levelItem = 1;

	void Start () {
        purchaseButton.onClick.AddListener(UpgradeItem);
        transform.Find("buttonPurchaseItem/Text").transform.GetComponent<Text>().text = price + "coins";
	}

    #region UpgradeItem
    void UpgradeItem ()
    {
        if (levelItem < 5 && (CharacterStatus.coinsWallet >= price))
        {
            CharacterStatus.isPurchaseOrUpgrade = true;
            CharacterStatus.itemPurchaseOrUpgrade = sendTo;
            CharacterStatus.coinsWallet -= price;
            price += price * 2;
            levelItem++;
            GameObject pointUpgrade = Instantiate(point);
            pointUpgrade.transform.SetParent(transform.Find("upgradeBar").transform);
            pointUpgrade.GetComponent<RectTransform>().localScale = new Vector3 (1f,1f,1f);
            transform.Find("buttonPurchaseItem/Text").transform.GetComponent<Text>().text = price + "coins";
        }
    }

    #endregion
}

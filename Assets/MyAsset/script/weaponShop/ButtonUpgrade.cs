using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrade : MonoBehaviour {

    AudioSource soundStore;
    public AudioClip upgradeSound;

    public string sendTo;
    public Button purchaseButton;  
    public GameObject point;

    public int price;
    int levelMaxItem = 5;
    int LevelItemPlayer;

	void Start () {
        //PlayerPrefs.DeleteAll();
        soundStore = GetComponent<AudioSource>();

        LevelItemStart();
        Debug.Log("LevelItemStart :" + LevelItemPlayer.ToString());
        purchaseButton.onClick.AddListener(UpgradeItem);
        transform.Find("buttonPurchaseItem/Text").transform.GetComponent<Text>().text = PriceLevelItem(LevelItemPlayer) + " coins";
        CheckLevelItem();
	}

    #region UpgradeItem
    void UpgradeItem ()
    {
        if (LevelItemPlayer < levelMaxItem && (PlayerPrefs.GetInt("money") >= PriceLevelItem(LevelItemPlayer)))
        {
            soundStore.PlayOneShot(upgradeSound);
            int moneyToUse = PlayerPrefs.GetInt("money");
            moneyToUse -= PriceLevelItem(LevelItemPlayer);
            PlayerPrefs.SetInt("money", moneyToUse);
            LevelItemPlayer++;
            PlayerPrefs.SetInt(sendTo + "Level",LevelItemPlayer);
            /*CharacterStatus.itemPurchaseOrUpgrade = sendTo;
            CharacterStatus.coinsWallet -= price;*/
            GameObject pointUpgrade = Instantiate(point);
            pointUpgrade.transform.SetParent(transform.Find("upgradeBar").transform);
            pointUpgrade.GetComponent<RectTransform>().localScale = new Vector3 (1f,1f,1f);
            transform.Find("buttonPurchaseItem/Text").transform.GetComponent<Text>().text = PriceLevelItem(LevelItemPlayer) + "coins";
            Debug.Log(PlayerPrefs.GetInt(sendTo +"Level"));
        }
    }

    void CheckLevelItem()
    {
        for (int i = 0; i < LevelItemPlayer; i++)
        {
            GameObject pointUpgrade = Instantiate(point);
            pointUpgrade.transform.SetParent(transform.Find("upgradeBar").transform);
            pointUpgrade.GetComponent<RectTransform>().localScale = new Vector3 (1f,1f,1f);
        }
    }

    int PriceLevelItem(int level)
    {
        int Price = price * (int)Mathf.Pow(2, level);
        return Price;
    }

    void LevelItemStart()
    {
        LevelItemPlayer = PlayerPrefs.GetInt(sendTo + "Level");
        if (LevelItemPlayer <= 0)
        {
            LevelItemPlayer = 1;
        }
    }
    #endregion

}

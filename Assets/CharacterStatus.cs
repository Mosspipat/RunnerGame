using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour {


    public static bool isPurchaseOrUpgrade;
    public static string itemPurchaseOrUpgrade;

    public static int amountHeadStartInt;
    public static int amountBariaInt;
    public static int amountPosionHeal;
    public static int amountLifeReborn;

    public static int levelAttack;
    public static int levelDefence;
    public static int levelMagnet;
    public static int levelImmortal;
    public static int levelCoin;

    /* void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/
	
    /* void Start()
    {
        PlayerPrefs.SetInt("money", 5000);
    }*/

	void Update () {
        UpdateStock();
        }

    void UpdateStock()
    {
        if (isPurchaseOrUpgrade)
        {
            switch (itemPurchaseOrUpgrade)
            {
                #region Item
                case "amountHeadStart":
                    amountHeadStartInt++;
                    break;
                case "amountBaria":
                    amountBariaInt++;
                    break;
                case "amountPosionHeal":
                    amountPosionHeal++;
                    break;
                case "amountLifeReborn":
                    amountLifeReborn++;
                    break;
                #endregion

                #region Upgrade
                case"levelAttack":
                    levelAttack++;
                    break;
                case "levelDefence":
                    levelDefence++;
                    break;
                case"levelMagnet":
                    levelMagnet++;
                    break;
                case"levelImmortal":
                    levelImmortal++;
                    break;
                case "levelCoin":
                    levelCoin++;
                    break;
                #endregion
            }
            isPurchaseOrUpgrade = false;
        }
    }
}

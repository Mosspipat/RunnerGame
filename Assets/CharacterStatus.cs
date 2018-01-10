using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour {


    public static int coinsWallet = 5000;
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

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	
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
                case "amountHeadStartInt":
                    amountHeadStartInt++;
                    Debug.Log("headStart +1");
                    break;
                case "amountBariaInt":
                    amountBariaInt++;
                    Debug.Log("Baria+1");
                    break;
                case "amountPosionHeal":
                    amountPosionHeal++;
                    Debug.Log("posionHeal+1");
                    break;
                case "amountLifeReborn":
                    amountLifeReborn++;
                    Debug.Log("reborn+1");
                    break;
                #endregion

                #region Upgrade
                case"levelAttack":
                    levelAttack++;
                    Debug.Log("upAtt");
                    break;
                case "levelDefence":
                    levelDefence++;
                    Debug.Log("upDef");
                    break;
                case"levelMagnet":
                    levelMagnet++;
                    Debug.Log("UpMagnet");
                    break;
                case"levelImmortal":
                    levelImmortal++;
                    Debug.Log("UpImmortal");
                    break;
                case "levelCoin":
                    levelCoin++;
                    Debug.Log("UpCoin");
                    break;
                #endregion
            }
            isPurchaseOrUpgrade = false;
        }
    }
}

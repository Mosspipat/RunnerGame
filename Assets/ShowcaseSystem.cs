using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowcaseSystem : MonoBehaviour {

    public List<Transform> showcasePoint;
    int  amountAllSword = 6;

    public int choseWeapon;
    public List<GameObject> levelSword; 

    public List <Transform> showingPoint;
    public List <Transform> swordType;
    public List <Transform> shieldType;

    public List <GameObject> setEquip;
    GameObject shield;
    GameObject sword;


    public Text dialogPurchase;
    int price = 500;
    int attackPower=1;
    int defencePower=2;

    public List<Text> dialogLevelToUnlock;
    public List<Image> lockImage;
    public List<Image> unlockImage;

    void Start () {
        EquipWeapon();
        LevelToUnlock();
    }
    
    void Update () {
        ChangePositionSword();
        DialogWeaponPurchase();
    }


    public void ChangePositionSword()
    {
        for(int i = 0 ;i<amountAllSword;i++)
        {
            levelSword[choseWeapon].transform.position = Vector3.Lerp(levelSword[choseWeapon].transform.position,showcasePoint[i].transform.position,5f*Time.deltaTime);
            choseWeapon++;
            if (choseWeapon > 5)
            {
                choseWeapon = 0;
            }
        }
    }

    public void EquipWeapon()
    {
        shield = Instantiate(shieldType[choseWeapon].gameObject,showingPoint[0].transform.position,showingPoint[0].transform.rotation);
        shield.transform.SetParent(showingPoint[0].transform);
        shield.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);


        sword = Instantiate(swordType[choseWeapon].gameObject,showingPoint[1].transform.position,showingPoint[1].transform.rotation);
        sword.transform.SetParent(showingPoint[1].transform);
        sword.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }

    public void DeleteEquip()
    {
        Destroy(shield.gameObject);
        Destroy(sword.gameObject);
    }

    #region buttonControl
    public void NextSword()
    {
        DeleteEquip();
        choseWeapon++;
        if (choseWeapon > 5)
        {
            choseWeapon = 0;
        }
        EquipWeapon();
    }

    public void PreviousSword()
    {
        DeleteEquip();
        choseWeapon--;
        if (choseWeapon < 0)
        {
            choseWeapon = 5;
        }
        EquipWeapon();
    }
    #endregion

    #region dialogPurchase
    void DialogWeaponPurchase()
    {
        switch (choseWeapon)
        {
            case 0:
                price = 100;
                attackPower = 1;
                defencePower = 1;
                break;
            case 1:
                price = 200;
                attackPower = 2;
                defencePower = 1;
                break;
            case 2:
                price = 500;
                attackPower = 1;
                defencePower = 2;
                break;
            case 3:
                price = 1000;
                attackPower = 2;
                defencePower = 2;
                break;
            case 4:
                price = 2000;
                attackPower = 3;
                defencePower = 2;
                break;
            case 5:
                price = 4000;
                attackPower = 3;
                defencePower = 3;
                break;
        }

        dialogPurchase.text = "Price " + price + "\n AT: +" + attackPower + " Def: +" + defencePower;
    }

    void LevelToUnlock()
    {
        int levelPlayer = 2;
        int isPurchase = 1;
        for (int i = 0; i < levelPlayer; i++)
        {
            /*if()  //playerPref weapon3Purchase,1
            {s
                dialogLevelToUnlock[i].text = "Purchased";
                continue;
            }*/
            lockImage[i+1].gameObject.SetActive(false);
            unlockImage[i+1].gameObject.SetActive(true);
            dialogLevelToUnlock[i+1].text = "can Unlock";
        }
    }
    #endregion


}

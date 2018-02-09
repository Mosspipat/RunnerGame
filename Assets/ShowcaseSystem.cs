using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowcaseSystem : MonoBehaviour {

    public List<AudioClip> soundStore;
    AudioSource audioGameplay;

    public int levelPlayer;
    public List<Transform> showcasePoint;
    int  amountAllSword = 6;

    public int chosenWeapon;
    int equipType;
    public List<GameObject> levelSword; 

    public List <Transform> showingPoint;
    public List <Transform> swordType;
    public List <Transform> shieldType;

    public List <GameObject> setEquip;
    GameObject shield;
    GameObject sword;


    public Text dialogPurchase;
    List<int> price = new List<int>();
    int attackPower=1;
    int defencePower=2;

    public List<Text> dialogLevelToUnlock;
    public List<Image> lockImage;
    public List<Image> unlockImage;

    public Text bankText;

    void Start () {
        audioGameplay =  transform.GetComponent<AudioSource>();

        PlayerPrefs.SetInt("weapon0Purchased", 1);
        equipType = PlayerPrefs.GetInt("weaponEquiped");    //clone weapon from last "weaponEquip"
        chosenWeapon = equipType;
        LevelToUnlock();
        PriceWeapon();
        StartEquipWeapon();
    }
    
    void Update () {
        ChangePositionSword();
        DialogWeaponPurchase();
    }

    void StartEquipWeapon()
    {
        EquipWeaponToHandCharacter();
        dialogLevelToUnlock[chosenWeapon].text = "equip";       
    }
        

    public void ChangePositionSword()
    {
        for(int i = 0 ;i<amountAllSword;i++)
        {
            levelSword[chosenWeapon].transform.position = Vector3.Lerp(levelSword[chosenWeapon].transform.position,showcasePoint[i].transform.position,5f*Time.deltaTime);
            chosenWeapon++;
            if (chosenWeapon > 5)
            {
                chosenWeapon = 0;
            }
        }
    }

    public void EquipWeaponToHandCharacter()
    {
        shield = Instantiate(shieldType[chosenWeapon].gameObject,showingPoint[0].transform.position,showingPoint[0].transform.rotation);
        shield.transform.SetParent(showingPoint[0].transform);
        shield.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

        sword = Instantiate(swordType[chosenWeapon].gameObject,showingPoint[1].transform.position,showingPoint[1].transform.rotation);
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
        audioGameplay.PlayOneShot(soundStore[0]);
        DeleteEquip();
        chosenWeapon++;
        if (chosenWeapon > 5)
        {
            chosenWeapon = 0;
        }
        EquipWeaponToHandCharacter();
    }

    public void PreviousSword()
    {
        audioGameplay.PlayOneShot(soundStore[0]);
        DeleteEquip();
        chosenWeapon--;
        if (chosenWeapon < 0)
        {
            chosenWeapon = 5;
        }
        EquipWeaponToHandCharacter();
    }

    public void Buy()
    {
        if (PlayerPrefs.GetInt("weapon" + chosenWeapon + "Purchased") == 1)
        {
            audioGameplay.PlayOneShot(soundStore[2]);
            Debug.Log("last equip "+ equipType + "changeTo Purchase");
            dialogLevelToUnlock[equipType].text = "purchased";    
            equipType = chosenWeapon;
            //equip weapon
            PlayerPrefs.SetInt("weaponEquiped", chosenWeapon);
            dialogLevelToUnlock[chosenWeapon].text = "equip";    // change that seleted to "equip"
            Debug.Log("equip type:" + chosenWeapon);
        }
        else if (PlayerPrefs.GetInt("money") >= price[chosenWeapon]&& levelPlayer >= chosenWeapon)
        {
            audioGameplay.PlayOneShot(soundStore[1]);
            unlockImage[chosenWeapon].gameObject.SetActive(false);
            PlayerPrefs.SetInt("weapon" + chosenWeapon + "Purchased", 1);
            dialogLevelToUnlock[chosenWeapon].text = "Purchased";

            int moneyPurchase = PlayerPrefs.GetInt("money");
            moneyPurchase -= price[chosenWeapon];
            PlayerPrefs.SetInt("money", moneyPurchase);

            Debug.Log("buy" + chosenWeapon);
        }
        else
        {
            Debug.Log("not enough level or money");
        }
    }

    public void BackToMenu()
    {
        audioGameplay.PlayOneShot(soundStore[3]);
        Application.LoadLevel("menuMap");
    }
    #endregion

    #region dialogPurchase
    void DialogWeaponPurchase()
    {
        switch (chosenWeapon)
        {
            case 0:
                attackPower = 1;
                defencePower = 1;
                break;
            case 1:
                attackPower = 2;
                defencePower = 1;
                break;
            case 2:
                attackPower = 1;
                defencePower = 2;
                break;
            case 3:
                attackPower = 2;
                defencePower = 2;
                break;
            case 4:
                attackPower = 3;
                defencePower = 2;
                break;
            case 5:
                attackPower = 3;
                defencePower = 3;
                break;
        }

        if(PlayerPrefs.GetInt("weapon" + chosenWeapon + "Purchased") == 1)
        {
            dialogPurchase.text ="AT: +" + attackPower + "Def: +" + defencePower;
        }

        else
        {
            dialogPurchase.text = "Price " + price[chosenWeapon] + "\n AT: +" + attackPower + " Def: +" + defencePower;
        }
    }

    void LevelToUnlock()
    {
        int maxPlayer = 5;
        for (int i = 0; i < levelPlayer; i++)
        {
            lockImage[i+1].gameObject.SetActive(false);
            unlockImage[i+1].gameObject.SetActive(true);
            dialogLevelToUnlock[i+1].text = "can Unlock";
        }

        // starter Check what's type purchase
        for(int i = 0; i< dialogLevelToUnlock.Count ;i++)
        {
            if (PlayerPrefs.GetInt("weapon" + (i) + "Purchased") == 1)
            {
                dialogLevelToUnlock[i].text = "Purchased";
                unlockImage[i].gameObject.SetActive(false);
            }
            else
            {
                dialogLevelToUnlock[i].text = "can Unlock";
            }
        }
        // can't unlock untill levelPlayer was complete
        for (int i = levelPlayer; i < maxPlayer; i++)
        {
            lockImage[i+1].gameObject.SetActive(true);
            unlockImage[i+1].gameObject.SetActive(false);
            dialogLevelToUnlock[i+1].text = "can Unlock with level "+ (i+1);
        }

    }


    void PriceWeapon()
    {
        price.Add(0); 
        price.Add(100);
        price.Add(500);
        price.Add(1000);
        price.Add(1500);
        price.Add(3000);
    }
    #endregion

    //PlayerPrefs.int(weapon" + (i) + "Purchased");
    //PlayerPrefs.int("weaponEquiped");
        
}

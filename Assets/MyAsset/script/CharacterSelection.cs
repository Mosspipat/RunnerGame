using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public List<Transform> allPos;

    public List<GameObject> allWeapon;
    public List<Vector3> allWeaponPos;
    public List<Quaternion> allWeaponRotation;
    
    public Transform handPlayerPoint;

    Transform presentPos;

    int startPos =0;
    public Transform positionProfile;
    public Transform positionCharacter;
    public Transform positionWeapon;
    public Transform positionItem;

    [HideInInspector]
    public int startWeapon;
    public GameObject axe;
    public GameObject ironMace;
    public GameObject knife;

    string classPlayer;
    public Text nameClass;
    public Text health;
    public Text typeWeapon;
    public Text skill;

    enum ClassGameplay{
        knight,Acher,Mage
    };


	void Start () {

        Camera.main.transform.position = positionProfile.transform.position;
        Camera.main.transform.rotation = positionProfile.transform.rotation;

        allPos = new List<Transform>();         //all Position
        allPos.Add(positionProfile);
        allPos.Add(positionCharacter);
        allPos.Add(positionWeapon);
        allPos.Add(positionItem);

        presentPos = allPos[startPos];              //start Position;


        //***Change to foreach 
        allWeapon = new List<GameObject>();      //all weapon
        allWeaponPos = new List<Vector3>();     //all WeaponPosition
        allWeaponRotation = new List<Quaternion>();  //all WeaponRotation
        allWeapon.Add(axe);
        allWeapon.Add(ironMace);
        allWeapon.Add(knife);

        foreach (GameObject weapons in allWeapon)
        {
            allWeaponPos.Add(weapons.transform.position);
            allWeaponRotation.Add(weapons.transform.rotation);
        }

        ClassPlayer((int)ClassGameplay.knight);
        startWeapon = 1;        //start Weapon
        typeWeapon.text = "IronMace";
	}
	
	void Update () {
        presentPos = allPos[startPos];
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, presentPos.transform.position, Time.deltaTime*3f);
        Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, presentPos.transform.rotation, Time.deltaTime*5f);
        EquipWeapon(startWeapon);
        /*ClassPlayer((int)ClassGameplay.knight); //type player selected*/
    }

    #region ButtonPress
    public  void PressLeft()
    {
        startPos--;
        if (startPos < 0)
        {
            startPos = 3;
        }
    }

    public void PressRight()
    {
        startPos++;
        if (startPos > 3)
        {
            startPos = 0;
        }
    }
    #endregion


    #region Weapon


    public void EquipWeapon(int typeWeapon)
    {
        allWeapon[typeWeapon].transform.position = handPlayerPoint.transform.position;
        allWeapon[typeWeapon].transform.rotation = handPlayerPoint.transform.rotation;
    }

    #endregion

    #region ClassPlayer
    void ClassPlayer(int typeClass)
    {
        switch (typeClass)
        {
            case 0:
            {
                    int HP = 3;
                    nameClass.text = "knight";
                    health.text = HP.ToString();
                break;
            }
            case 1:
                {
                    int HP = 2;
                    nameClass.text = "archer";
                    health.text = HP.ToString();
                    break;
                }
            case 2:
                {
                    int HP = 1;
                    nameClass.text = "mage";
                    health.text = HP.ToString();
                    break;
                }
        }
    }   
    #endregion
}

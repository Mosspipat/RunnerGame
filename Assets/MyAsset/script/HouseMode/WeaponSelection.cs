using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour {

    public int numWeapon;
    CharacterSelection CSplayer;

    void Start()
    {
        CSplayer = GameObject.Find("systemControl").transform.GetComponent<CharacterSelection>();
    }

    public void OnMouseDown()
    {
        for (int i = 0; i < CSplayer.allWeapon.Count; i++)                              //foreach place weapon's Position to original Position;
        {
            CSplayer.allWeapon[i].transform.position = CSplayer.allWeaponPos[i];
            CSplayer.allWeapon[i].transform.rotation= CSplayer.allWeaponRotation[i];
        }

        /*foreach (Transform Weapon in CSplayer.allWeapon)
        {
            Weapon.transform.position = CSplayer.allWeaponPos.FindIndex();
        }*/

        CSplayer.startWeapon = numWeapon;
        CSplayer.typeWeapon.text = this.gameObject.name;

        Debug.Log("selected :" + numWeapon);
    }
}

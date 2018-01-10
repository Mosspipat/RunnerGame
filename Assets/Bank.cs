using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bank : MonoBehaviour {

	void Update () {
        if (CharacterStatus.coinsWallet <= 0)
        {
            CharacterStatus.coinsWallet = 0;
        }
        transform.Find("panelBank/textBank").GetComponent<Text>().text = "Yours coins : \n" + CharacterStatus.coinsWallet;
	}
}

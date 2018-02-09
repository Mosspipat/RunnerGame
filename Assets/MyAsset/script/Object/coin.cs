using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour {

    UIPlayer uiPlayer;

    public static int numberCoinAllSpawn = 0;
    int numberThisCoin;
    GameObject player;
    public GameObject CoinEffect;
    float offsetBackwardPlayer = 10f;

	void Start () {

        uiPlayer = GameObject.Find("player/UIPlayer").GetComponent<UIPlayer>();

        player = GameObject.Find("player");
        numberThisCoin = numberCoinAllSpawn;
        MagnetEffect.allCoins.Add(this.gameObject);
        numberCoinAllSpawn++;
	}
	
	void FixedUpdate () {
        this.transform.Rotate(new Vector3(Time.deltaTime*100f, 0, 0));
        CheckOutFromListAllCoins();
        DestroyitSelf();
	}

    void OnTriggerEnter(Collider obj)                               //Interact with item
    {
        if (obj.name == "player")
        {
            MagnetEffect.allCoins.Remove(this.gameObject);
            UIPlayer.sizeCoinImage = new Vector2(15f, 15f);
            uiPlayer.intergerScoreCoin +=1;

            // Save new money
            int money = PlayerPrefs.GetInt("money");
            money++;
            PlayerPrefs.SetInt("money", money);

            GameObject.Find("MainCamera/ProgressPlayer/coinBar/coinImage").transform.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(30f, 30f);
            GameObject effect = Instantiate(CoinEffect, this.transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            Destroy(this.gameObject);
        }
    }

    void DestroyitSelf()
    {
        if (this.gameObject.transform.position.z < player.transform.position.z - offsetBackwardPlayer)
        {
            Debug.Log("coin destroy");
            Destroy(this.gameObject);
        }
    }

    void CheckOutFromListAllCoins()
    {
        if (this.gameObject == null)
        {
            Debug.Log("Coin Check out");
            MagnetEffect.allCoins.Remove(this.gameObject);
        }
    }

    void OnDestroy() {
        MagnetEffect.allCoins.Remove(this.gameObject);
    }
}

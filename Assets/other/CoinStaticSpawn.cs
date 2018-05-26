using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStaticSpawn : MonoBehaviour {

    public List<GameObject> coinStatic = new List<GameObject>();

    void Update()
    {
        if (this.gameObject == null)
        {
            DestroyCoinInListCoin();
        }
    }

    void DestroyCoinInListCoin()
    {
        foreach(GameObject coins in coinStatic)
        {
            MagnetEffect.allCoins.Remove(coins.gameObject);
        }
    }
}

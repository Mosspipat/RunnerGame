using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventMonster : MonoBehaviour {

    public GameObject bullet;
    public Transform ShotPoint; 

    #region Shoot
    public void Shoot()
    {
        GameObject bulletEnemy = Instantiate(bullet,ShotPoint.position,ShotPoint.rotation);
        bulletEnemy.name = "bullet";
    }
    #endregion
}

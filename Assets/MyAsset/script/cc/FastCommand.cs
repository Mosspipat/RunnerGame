using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCommand : MonoBehaviour {

    public static void ResetDataSave()
    {
        PlayerPrefs.DeleteAll();
    }
}

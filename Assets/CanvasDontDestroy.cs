using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDontDestroy : MonoBehaviour {

    private static CanvasDontDestroy CanvasSelectionScene_Instance;

    void Awake()
    {
        if (!CanvasSelectionScene_Instance)
        {
            CanvasSelectionScene_Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPage : MonoBehaviour {


    int page;

    public Text textExplain;
    public GameObject pos;

	void Start () {
        page = 0;
	}
	
	void Update () {
        PageSelect();
	}

  public void Previous()
    {
        page++;

        if (page > 4)
        {
            page = 0;
        }
    }

   public void Next()
    {
        page--;

        if (page < 0)
        {
            page = 4;
        }
    }

    void PageSelect()
    {
        switch (page)
        {
            case 0:
                textExplain.text = "stand in front of Kinect with 2.5 metres";
                CheckPage(0);
                break;
            case 1:
                textExplain.text = "raise right hand to move player to the right";
                CheckPage(1);
                break;
            case 2:
                textExplain.text = "raise left hand to move player to the left";
                CheckPage(2);
                break;
            case 3:
                textExplain.text = "action little jump to make player jump";
                CheckPage(3);
                break;
            case 4:
                textExplain.text = "action little squat to make player slide";
                CheckPage(4);
                break;
        }
    }

    void CheckPage(int pageSet)
    {
        Debug.Log("hide");

        for(int i= 0;i<pos.transform.childCount;i++)
        {
            pos.transform.GetChild(i).gameObject.SetActive(false);
        }

        pos.transform.GetChild(pageSet).gameObject.SetActive(true);
    }

    #region back
    public void GotoMenu()
    {
        Application.LoadLevel("menuStart");  
    }
    #endregion

}

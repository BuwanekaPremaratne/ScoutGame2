using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClosePanelManager : MonoBehaviour
{
    SpinPanelManager spinManager;
    public GameObject Panel;
    public GameObject gamePanel;

    void Start()
    {
        spinManager = GameObject.FindObjectOfType<SpinPanelManager>();

    }


    public void closePanels()
    {
        if (Panel.name == "Note Panel(Clone)")
        {
            spinManager.ShowGamebord();

        }
        else
        {
            Debug.Log("Panel Name is :" + Panel.name);
        }

        Destroy(Panel);
    }
}

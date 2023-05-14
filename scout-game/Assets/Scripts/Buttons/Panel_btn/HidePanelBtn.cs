using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelBtn : MonoBehaviour
{

    //cached Panel Manager
    private PanelManager _panelManager;

    private void Start()
    {

        // cache this 
        _panelManager = PanelManager.instance;

    }

    public void DoHidePanel()
    {
       _panelManager.HideLastPanel();
       Debug.Log("Hide panel");
       
    }
   
}

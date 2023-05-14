using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public string PanelId;

    //cached Panel Manager

    private PanelManager _panelManager;

    private void Start()
    {

        // cache this 
        _panelManager = PanelManager.instance;

    }

    public void DoShowPanel()
    {
       _panelManager.ShowPanel(PanelId);
       Debug.Log("Do show panel");
       
    }
}

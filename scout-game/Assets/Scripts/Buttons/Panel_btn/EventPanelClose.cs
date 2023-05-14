using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanelClose : MonoBehaviour
{
    public GameObject gameBoardPanel;// refference to game board panel 

    private SpinPanelManager spinPanelManager;

    private GameObject Newpanel;
   

    public void SetPanel(GameObject panel)
    {
        Newpanel=panel;

    }

     public void ClosePanel()
    {
        Debug.Log("Panel to close"+ Newpanel);
        // if (close)
        // {

        //     // Check if the stack is empty
        //     if (panelStack.Count == 0)
        //     {
        //         Debug.Log("Panel stack is empty." + " and Stack list" + NewpanelStack);
        //         return;
        //     }

        //     // Pop the top item from the stack
        //     GameObject panel = panelStack.Pop();

        //     // Destroy the panel
        //     Destroy(panel);

        // }

    }

    
}

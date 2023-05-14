using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[Serializable]
public class PanelManager : Singelton<PanelManager>
{
     //available panels form PanelManager 
    public List<PanelModel> Panels;

    //store instances 
    private List<PanelInstanceModel> _panelInstancesList= new List<PanelInstanceModel>();

    public void ShowPanel(string panelId)
    {

        PanelModel panelModel=Panels.FirstOrDefault(panel=>panel.PanelId==panelId);

        if(panelModel!=null){
            //pop up the panel 
            
            //create new instance 
            var newInsatancePanel=Instantiate(panelModel.panelPrefab,transform);

            //add the panel to queue 
            _panelInstancesList.Add(new PanelInstanceModel
                {
                    PanelId=panelId,
                    panelInstance=newInsatancePanel

                }
            );
            Debug.Log($"Create New Instance {panelId} and {newInsatancePanel} and queue{_panelInstancesList}");
        }
        else{
            Debug.LogWarning($"cant find panel with {panelId}");

        }
        

    }
    

    public void HideLastPanel()
    {
        if(isPanelShowing())
        {
            //Get the last panel
            var lastPanel=_panelInstancesList[_panelInstancesList.Count-1];

            _panelInstancesList.Remove(lastPanel);

            //Destroy the last panel instance
            Destroy(lastPanel.panelInstance);
            Debug.Log($"panel is showing{lastPanel} ");
        }
        else
        {
            
            Debug.Log($"no panel is showing and queue is");

        }
    }
    
    //See if any panel is displayed already 
    public bool isPanelShowing()
    {
        return GetPanelAmount() >0;


    }

    //Return How many panels in a queue
    public int GetPanelAmount()
    {
      return _panelInstancesList.Count;
    }
}


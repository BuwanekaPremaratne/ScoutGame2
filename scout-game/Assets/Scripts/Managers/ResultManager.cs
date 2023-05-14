using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public GameObject resultPanelQuest;
    public Color wrongColor;

    private GameObject resultPanel;

    private SpinPanelManager spinManager;

    void Start()
    {
        spinManager = GameObject.FindObjectOfType<SpinPanelManager>();

    }


    public void ShowResultPanel(int result, string type)
    {
        Debug.Log("Showing result" + result);


        // Find the child Text components of resultPanelQuest

        TextMeshProUGUI resultTextComponent = resultPanelQuest.transform.Find("answer_result").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI expComponent = resultPanelQuest.transform.Find("exp_result").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI resultLable = resultPanelQuest.transform.Find("exp_result_lable").GetComponent<TextMeshProUGUI>();
        

        if (type == "question")
        {
            //check whether answer is correct or wrong
            if (result == 1)
            {
                // Set the text of the Text components
                resultTextComponent.text = "Correct Answer";
                resultLable.text="Points";
                expComponent.text = "+1";
                

                // instantiate the result 
                GameObject resultPanel = Instantiate(resultPanelQuest, transform);

            }
            else
            {
                // Set the text of the Text components
                resultTextComponent.text = "Wrong Answer";
                resultLable.text="Points";
                expComponent.text = "0";
                resultTextComponent.color = new Color(wrongColor.r, wrongColor.g, wrongColor.b, 1f);// set the color of the text 

                // instantiate the result 
                GameObject resultPanel = Instantiate(resultPanelQuest, transform);

            }

        }
        if (type == "event")
        {
            //check whether answer is correct or wrong
            if (result == 1)
            {
                // Set the text of the Text components
                resultTextComponent.text = "Well Done";
                expComponent.text = "25";

                // instantiate the result 
                GameObject resultPanel = Instantiate(resultPanelQuest, transform);

            }
            else
            {
                // Set the text of the Text components
                resultTextComponent.text = "Mabey Next Time";
                expComponent.text = "00";
                resultTextComponent.color = new Color(wrongColor.r, wrongColor.g, wrongColor.b, 1f);// set the color of the text 

                // instantiate the result 
                GameObject resultPanel = Instantiate(resultPanelQuest, transform);

            }

        }



    }

    public void closeResults()
    {
        Destroy(resultPanelQuest);
        spinManager.ShowGamebord();
    }
}

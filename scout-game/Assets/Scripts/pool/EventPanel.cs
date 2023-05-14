using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;


public class EventQuestion
{
    public string eventId;
    public string questionText;
    public string[] answerOptions;
    public int correctAnswerIndex;
    public bool isCalled;
    private string category = "";



    public EventQuestion(string eventId, string questionText, string[] answerOptions, int correctAnswerIndex)
    {
        this.eventId = eventId;
        this.questionText = questionText;
        this.answerOptions = answerOptions;
        this.correctAnswerIndex = correctAnswerIndex;
        this.isCalled = false;
    }
}


public class EventPanel : MonoBehaviour
{


    //Event List
    private List<EventQuestion> unusedEventQuestions = new List<EventQuestion>();

    public TextMeshProUGUI questionText;
    public Button[] answerButtons;

    private ResultManager resultManager;
    private int flag;
    private string category = "";

    private void Start()
    {
        resultManager = GameObject.FindObjectOfType<ResultManager>();
        GenerateRandomQuestion();


    }
    private void DisplayQuestionInPanel(EventQuestion question)
    {
        questionText.text = question.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.answerOptions[i];
            int buttonIndex = i; // Store the current button index in a separate variable to use in the lambda expression
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex == question.correctAnswerIndex, question));
        }
    }
    private void CheckAnswer(bool isCorrect, EventQuestion question)
    {
        string type = "event";
        if (!isCorrect)
        {
            flag = 0;

            Debug.Log("Wrong answer.");
            resultManager.ShowResultPanel(flag, type);
        }
        else
        {
            flag = 1;
            Debug.Log("Correct answer!");
            resultManager.ShowResultPanel(flag, type);

            //add the quetion to used usedquetions 
            usedFlav.usedEvents.Add(question);

            Debug.Log("cato: " + category);

            removeQuestion(category, question);



        }
    }


    private void CheckUsedQuestion(EventQuestion question)
    {
        
        if (usedFlav.usedEvents.Any(q => q.eventId == question.eventId))
        {
            Debug.Log("Question has been used before.");


        }
        else
        {
            Debug.Log("Question is new.");

            // Display the question in the panel
               DisplayQuestionInPanel(question);


        }

    }
    // function to remove the quesion 
    private void removeQuestion(string category, EventQuestion question)
    {
        Debug.Log("catergory :" + category);

        // Remove the random question from its corresponding category
        switch (category)
        {
            case "intellect":
                EventPool.intellectEvents.Remove(question);
                break;
            case "physical":
                EventPool.phyEvents.Remove(question);
                break;

            default:
                Debug.Log("Invalid category.");
                break;
        }

    }


    private void GenerateRandomQuestion()
    {

        // Choose a random category 
        int randomCategoryIndex = RandomeNumSelector.EventNumSelector();


        // Choose a random question from the selected category
        EventQuestion randomQuestion = null;
        switch (randomCategoryIndex)
        {
            case 0:
                if (QuizPool.historyQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, EventPool.intellectEvents.Count);
                    randomQuestion = EventPool.intellectEvents[randomIndex];
                    category = "intellect";

                }
                break;

            case 1:
                if (EventPool.phyEvents.Count > 0)
                {
                    int randomIndex = Random.Range(0, EventPool.phyEvents.Count);
                    randomQuestion = EventPool.phyEvents[randomIndex];
                    category = "physical";
                }
                break;
        }

        if (randomQuestion != null)
        {

            CheckUsedQuestion(randomQuestion);
        }
        else
        {
            Debug.Log("No questions left in the selected category.");
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;


//please consider this is only for Quest 
public class QuizQuestion
{
    public string questId;
    public string questionText;
    public string[] answerOptions;
    public int correctAnswerIndex;
    public bool isCalled;



    public QuizQuestion(string questId, string questionText, string[] answerOptions, int correctAnswerIndex)
    {
        this.questId = questId;
        this.questionText = questionText;
        this.answerOptions = answerOptions;
        this.correctAnswerIndex = correctAnswerIndex;
        this.isCalled = false;
    }
}



public class QuizAndEventPanel : MonoBehaviour
{
    //Quize List
    private List<QuizQuestion> unusedQuizQuestions = new List<QuizQuestion>();


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

    //function to display the question in the quiz panel 
    private void DisplayQuestionInPanel(QuizQuestion question)
    {

        Debug.Log("Displaying the answers");
        questionText.text = question.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.answerOptions[i];
            int buttonIndex = i; // Store the current button index in a separate variable to use in the lambda expression
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex == question.correctAnswerIndex, question));
        }
    }

    //Function to check whether the quetion is correct 
    private void CheckAnswer(bool isCorrect, QuizQuestion question)
    {
        string type="question";
        if (!isCorrect)
        {
            flag = 0;

            Debug.Log("Wrong answer.");
            resultManager.ShowResultPanel(flag,type);
        }
        else
        {
            
            flag = 1;
            Debug.Log("Correct answer!");
            resultManager.ShowResultPanel(flag,type);

            //add the quetion to used usedquetions 
            usedFlav.usedQuizQuestions.Add(question);

            // Update the player's stats
            PlayerStats.playerStat[category]++;
            Debug.Log("cato: " + category);

            //remove the question
            removeQuestion(category,question);




        }
    }


    //check whther the genarated quetion is used before or retun falls 
    private void CheckUsedQuestion(QuizQuestion question)
    {
        if (usedFlav.usedQuizQuestions.Any(q => q.questId == question.questId))
        {
            Debug.Log("Question has been used before.");



        }
        else
        {
            Debug.Log("Question is new.");
            DisplayQuestionInPanel(question);

        }

    }

    // function to remove the quesion 
    private void removeQuestion(string category,QuizQuestion question)
    {
        Debug.Log("catergory :" + category);

        // Remove the random question from its corresponding category
        switch (category)
        {
            case "scouting_history":
                QuizPool.historyQuestions.Remove(question);
                break;
            case "founder":
                QuizPool.founderQuestions.Remove(question);
                break;
            case "cultural_knowledge":
                QuizPool.culturalQuestions.Remove(question);
                break;
            case "estimations":
                QuizPool.estimationsQuestions.Remove(question);
                break;
            case "exploration":
                QuizPool.explorationQuestions.Remove(question);
                break;
            case "pioneering":
                QuizPool.pioneeringQuestions.Remove(question);
                break;
            case "firstaid":
                QuizPool.firstaidQuestions.Remove(question);
                break;
            case "woodsman_Craft":
                QuizPool.woodsmanQuestions.Remove(question);
                break;
            default:
                Debug.Log("Invalid category.");
                break;
        }

    }

    private void GenerateRandomQuestion()
    {

        
        // Choose a random category 
        // int randomCategoryIndex = Random.Range(0, 7);

        
        int  randomCategoryIndex= RandomeNumSelector.QuizNumSelector();

       
        // Choose a random question from the selected category
        QuizQuestion randomQuestion = null;
        Debug.Log("Displaying the answers");
        switch (randomCategoryIndex)
        {
            case 0:
                if (QuizPool.historyQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.historyQuestions.Count);
                    randomQuestion = QuizPool.historyQuestions[randomIndex];
                    // QuizPool.historyQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "scouting_history";
                }
                else
                {
                    Debug.Log("no quetions left");
                }
                break;

            case 1:
                if (QuizPool.founderQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.founderQuestions.Count);
                    randomQuestion = QuizPool.founderQuestions[randomIndex];
                    QuizPool.founderQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "founder";
                }
                break;

            case 2:
                if (QuizPool.culturalQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.culturalQuestions.Count);
                    randomQuestion = QuizPool.culturalQuestions[randomIndex];
                    QuizPool.culturalQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "cultural_knowledge";
                }
                break;

            case 3:
                if (QuizPool.estimationsQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.estimationsQuestions.Count);
                    randomQuestion = QuizPool.estimationsQuestions[randomIndex];
                    QuizPool.estimationsQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "estimations";
                }
                break;
            case 4:
                if (QuizPool.explorationQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.explorationQuestions.Count);
                    randomQuestion = QuizPool.explorationQuestions[randomIndex];
                    QuizPool.explorationQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "exploration";
                }
                break;
            case 5:
                if (QuizPool.pioneeringQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.pioneeringQuestions.Count);
                    randomQuestion = QuizPool.pioneeringQuestions[randomIndex];
                    QuizPool.pioneeringQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "pioneering";
                }
                break;
            case 6:
                if (QuizPool.firstaidQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.firstaidQuestions.Count);
                    randomQuestion = QuizPool.firstaidQuestions[randomIndex];
                    QuizPool.firstaidQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "pioneering";
                }
                break;
            case 7:
                if (QuizPool.woodsmanQuestions.Count > 0)
                {
                    int randomIndex = Random.Range(0, QuizPool.woodsmanQuestions.Count);
                    randomQuestion = QuizPool.woodsmanQuestions[randomIndex];
                    QuizPool.woodsmanQuestions.RemoveAt(randomIndex);
                    randomQuestion.isCalled = true;
                    category = "woodsman_Craft";
                }
                break;
        }

        if (randomQuestion != null)
        {
            // check whether the question is used before 
            CheckUsedQuestion(randomQuestion);
            Debug.Log("catergory :" + category);
        }
        else
        {
            Debug.Log("No questions left in the selected category.");
        }


    }



}






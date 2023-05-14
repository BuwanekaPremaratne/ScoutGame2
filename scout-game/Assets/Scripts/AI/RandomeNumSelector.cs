using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomeNumSelector
{

    // Selector for Quizes
    public static int QuizNumSelector()
    {
        List<int> result = new List<int>();

        if (QuizPool.historyQuestions.Count > 0)
        {
            result.Add(0);
        }
        if (QuizPool.founderQuestions.Count > 0)
        {
            result.Add(1);
        }
        if (QuizPool.culturalQuestions.Count > 0)
        {
            result.Add(2);
        }
        if (QuizPool.estimationsQuestions.Count > 0)
        {
            result.Add(3);
        }
        if (QuizPool.explorationQuestions.Count > 0)
        {
            result.Add(4);
        }
        if (QuizPool.pioneeringQuestions.Count > 0)
        {
            result.Add(5);
        }
        if (QuizPool.firstaidQuestions.Count > 0)
        {
            result.Add(6);
        }
        if (QuizPool.woodsmanQuestions.Count > 0)
        {
            result.Add(7);
        }

        int[] cat=result.ToArray();
        Debug.Log(cat);

        int randomIndex = Random.Range(0, cat.Length);
        int randomNumber = cat[randomIndex];

        return randomNumber;

        
    }

    public static int EventNumSelector()
    {
        List<int> result = new List<int>();

        if (EventPool.intellectEvents.Count > 0)
        {
            result.Add(0);
        }
        if (EventPool.phyEvents.Count > 0)
        {
            result.Add(1);
        }
        

        int[] cat=result.ToArray();
        Debug.Log(cat);

        int randomIndex = Random.Range(0, cat.Length);
        int randomNumber = cat[randomIndex];

        return randomNumber;

        
    }





    // Selector for Events

}


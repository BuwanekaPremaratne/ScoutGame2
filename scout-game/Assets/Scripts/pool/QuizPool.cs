using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPool : MonoBehaviour
{
    public static List<QuizQuestion> historyQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q1","What is the capital of France?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q2","What is the largest planet in our solar system?", new string[]{"Jupiter", "Saturn", "Uranus", "Neptune"}, 0)
    };
    public static List<QuizQuestion> founderQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q3","In what year did World War II end?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q4","Who was the first president of the United States?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0)
    };

    public static List<QuizQuestion> culturalQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q5","What is the smallest unit of life?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q6","What is the largest organ in the human body?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0)
    };

    public static List<QuizQuestion> estimationsQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q7","Which country won the first FIFA World Cup?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q8","Which athlete has won the most Olympic medals?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0)
    };
    public static List<QuizQuestion> explorationQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q1","What is the capital of France?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q2","What is the largest planet in our solar system?", new string[]{"Jupiter", "Saturn", "Uranus", "Neptune"}, 0)
    };
    public static List<QuizQuestion> pioneeringQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q3","In what year did World War II end?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q4","Who was the first president of the United States?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0)
    };

    public static List<QuizQuestion> firstaidQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q5","What is the smallest unit of life?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q6","What is the largest organ in the human body?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0)
    };

    public static List<QuizQuestion> woodsmanQuestions = new List<QuizQuestion>()
    {
        new QuizQuestion("q7","Which country won the first FIFA World Cup?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0),
        new QuizQuestion("q8","Which athlete has won the most Olympic medals?", new string[]{"Paris", "London", "Berlin", "Madrid"}, 0)
    };


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPool : MonoBehaviour
{
    public static List<EventQuestion> intellectEvents = new List<EventQuestion>()
    {
        new EventQuestion("q1", "What is the capital of France?", new string[] { "Paris", "London", "Berlin" }, 0),
        new EventQuestion("q2", "What is the largest planet in our solar system?", new string[] { "Jupiter", "Saturn", "Uranus" }, 0),
        new EventQuestion("q2", "What is the largest planet in our solar system?", new string[] { "Jupiter", "Saturn", "Uranus" }, 0),
        new EventQuestion("q2", "What is the largest planet in our solar system?", new string[] { "Jupiter", "Saturn", "Uranus" }, 0)
    };

    public static List<EventQuestion> phyEvents = new List<EventQuestion>()
    {
        new EventQuestion("q1", "What is the capital of France?", new string[] { "Paris", "London", "Berlin" }, 0),
        new EventQuestion("q2", "What is the largest planet in our solar system?", new string[] { "Jupiter", "Saturn", "Uranus" }, 0),
        new EventQuestion("q2", "What is the largest planet in our solar system?", new string[] { "Jupiter", "Saturn", "Uranus" }, 0),
        new EventQuestion("q2", "What is the largest planet in our solar system?", new string[] { "Jupiter", "Saturn", "Uranus" }, 0),
        new EventQuestion("q2", "What is the largest planet in our solar system?", new string[] { "Jupiter", "Saturn", "Uranus" }, 0)
    };


};




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public Text timeText;

    void Update()
    {
        if (timeRemaining > 0)
        {
           
            timeRemaining -= Time.deltaTime;
            timeText.text = Mathf.RoundToInt(timeRemaining).ToString();
        }
        else
        {
            // Debug.Log("Timer not Started");
        }
    }
}
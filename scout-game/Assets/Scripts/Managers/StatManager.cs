using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatManager : MonoBehaviour
{
    
    void Start()
    {

        UpdateStatsUI();
    }

    // updating stats 
    public void UpdateStatsUI()
    {
        TextMeshProUGUI scoutingHistory = GameObject.Find("current_score_1")?.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI founder = GameObject.Find("current_score_2").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI cultural_knowledge = GameObject.Find("current_score_3").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI estimations = GameObject.Find("current_score_4").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI exploration = GameObject.Find("current_score_5").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI pioneering = GameObject.Find("current_score_6").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI first_aid = GameObject.Find("current_score_7").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI woodsman_Craft = GameObject.Find("current_score_8").GetComponent<TextMeshProUGUI>();




        scoutingHistory.text = PlayerStats.playerStat["scouting_history"].ToString();
        founder.text = PlayerStats.playerStat["founder"].ToString();
        cultural_knowledge.text = PlayerStats.playerStat["cultural_knowledge"].ToString();
        estimations.text = PlayerStats.playerStat["estimations"].ToString();
        exploration.text = PlayerStats.playerStat["exploration"].ToString();
        pioneering.text = PlayerStats.playerStat["pioneering"].ToString();
        first_aid.text = PlayerStats.playerStat["first_aid"].ToString();
        woodsman_Craft.text = PlayerStats.playerStat["woodsman_Craft"].ToString();
    }

}
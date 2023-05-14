using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static Dictionary<string, int> playerStat = new Dictionary<string, int>()
    {
        {"scouting_history", 10},
        {"founder", 10},
        {"cultural_knowledge", 10},
        {"estimations", 10},
        {"exploration", 10},
        {"pioneering", 10},
        {"first_aid", 10},
        {"woodsman_Craft", 10}
    };

    public static int playerExp=500;


}
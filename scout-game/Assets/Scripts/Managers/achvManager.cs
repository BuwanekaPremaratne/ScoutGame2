using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achvManager : MonoBehaviour
{
    public GameObject isStats;
    public GameObject isExp;
    public GameObject intBadge;
    public GameObject phyBadge;
    public GameObject comBadge;


    void Start()
    {
        int x1 = PlayerStats.playerStat["scouting_history"];
        int x2 = PlayerStats.playerStat["founder"];
        int x3 = PlayerStats.playerStat["cultural_knowledge"];
        int x4 = PlayerStats.playerStat["estimations"];
        int x5 = PlayerStats.playerStat["exploration"];
        int x6 = PlayerStats.playerStat["pioneering"];
        int x7 = PlayerStats.playerStat["first_aid"];
        int x8 = PlayerStats.playerStat["woodsman_Craft"];

        int totalInt = x1 + x2 + x3 + x4 + x5;
        int totaphy = x6 + x7 + x8;
        int total = totalInt + totaphy;

        if (totalInt >= 50)
        {
            intBadge.SetActive(true);

        }

        if (totaphy >= 30)
        {
            phyBadge.SetActive(true);

        }

        if (total >= 80)
        {
            isStats.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);


        }
        if (PlayerStats.playerExp >= 500)
        {
             isExp.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);

        }
        if (total == 80 && PlayerStats.playerExp >= 500)
        {
            comBadge.SetActive(true);

        }


    }

}

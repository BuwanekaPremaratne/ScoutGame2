using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[DataContract]
public class PlayerData
{
    [DataMember]
    public Dictionary<string, int> playerStat;

    [DataMember]
    public int playerExp;

     [DataMember]
    public List<QuizQuestion> historyQuestions;
    [DataMember]
    public List<QuizQuestion> founderQuestions;
    [DataMember]
    public List<QuizQuestion> culturalQuestions;
    [DataMember]
    public List<QuizQuestion> estimationsQuestions;
    [DataMember]
    public List<QuizQuestion> explorationQuestions;
    [DataMember]
    public List<QuizQuestion> pioneeringQuestions;
    [DataMember]
    public List<QuizQuestion> firstaidQuestions;
    [DataMember]
    public List<QuizQuestion> woodsmanQuestions;
    [DataMember]
    public List<EventQuestion> intellectEvents;
    [DataMember]
    public List<EventQuestion> phyEvents;
    [DataMember]
    public List<Notes> notes;

    [DataMember]
    public List<QuizQuestion> usedQuizQuestions;
    public List<EventQuestion> usedEvents;
    public List<Notes>usedNotes;
    

    

    

}

// public class PlayerData
// {
//     PlayerStats.playerStat;//dic
//     PlayerStats.playerExp;//int
//     usedFlav.usedQuizQuestions;//list
//     usedFlav.usedEvents;//list
//     usedFlav.usedNotes;//list
    

// }

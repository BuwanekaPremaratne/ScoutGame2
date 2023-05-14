using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManger : MonoBehaviour
{
    public static void SavePlayerData()
    {
        PlayerData playerData = new PlayerData();
        playerData.playerStat = PlayerStats.playerStat;
        playerData.playerExp = PlayerStats.playerExp;
        playerData.historyQuestions = QuizPool.historyQuestions;
        playerData.founderQuestions = QuizPool.founderQuestions;
        playerData.culturalQuestions = QuizPool.culturalQuestions;
        playerData.estimationsQuestions = QuizPool.estimationsQuestions;
        playerData.explorationQuestions = QuizPool.explorationQuestions;
        playerData.pioneeringQuestions = QuizPool.pioneeringQuestions;
        playerData.firstaidQuestions = QuizPool.firstaidQuestions;
        playerData.woodsmanQuestions = QuizPool.woodsmanQuestions;
        playerData.intellectEvents = EventPool.intellectEvents;
        playerData.phyEvents = EventPool.phyEvents;
        playerData.notes = NotePool.notes;

        playerData.usedQuizQuestions = usedFlav.usedQuizQuestions;
        playerData.usedEvents = usedFlav.usedEvents;
        playerData.usedNotes = usedFlav.usedNotes;


        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
        bf.Serialize(file, playerData);
        file.Close();

        Debug.Log("Player data saved!");
    }

    public static void LoadPlayerData()
    {
        // check if the file exists
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {

            // create a binary formatter and a file stream
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);

            try
            {
                // deserialize the data and cast it to PlayerData type
                PlayerData playerData = (PlayerData)bf.Deserialize(file);

                // close the file stream
                file.Close();

                // assign the loaded data to the appropriate variables
                PlayerStats.playerStat = playerData.playerStat;
                PlayerStats.playerExp = playerData.playerExp;
                usedFlav.usedQuizQuestions = playerData.usedQuizQuestions;
                usedFlav.usedEvents = playerData.usedEvents;
                usedFlav.usedNotes = playerData.usedNotes;
                QuizPool.historyQuestions = playerData.historyQuestions;
                QuizPool.founderQuestions = playerData.founderQuestions;
                QuizPool.culturalQuestions = playerData.culturalQuestions;
                QuizPool.estimationsQuestions = playerData.estimationsQuestions;
                QuizPool.explorationQuestions = playerData.explorationQuestions;
                QuizPool.pioneeringQuestions = playerData.pioneeringQuestions;
                QuizPool.firstaidQuestions = playerData.firstaidQuestions;
                QuizPool.woodsmanQuestions = playerData.woodsmanQuestions;
                EventPool.intellectEvents = playerData.intellectEvents;
                EventPool.phyEvents = playerData.phyEvents;
                NotePool.notes = playerData.notes;

            }
            catch (Exception e)
            {
                // handle any deserialization exceptions
                Debug.Log("Error loading player data: " + e.Message);
                file.Close();
            }
        }

    }
}

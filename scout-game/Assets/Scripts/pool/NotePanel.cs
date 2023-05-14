using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Notes
{
    public string noteID;
    public string NoteText;
    public string NoteTiltleText;
    public bool isCalled;



    public Notes(string noteID, string NoteText, string NoteTiltleText)
    {
        this.noteID = noteID;
        this.NoteText = NoteText;
        this.NoteTiltleText = NoteTiltleText;
        this.isCalled = false;
    }
}

public class NotePanel : MonoBehaviour
{
    //Quize List
    

    //Event List


    public TextMeshProUGUI NoteText;
    public TextMeshProUGUI NoteTitleText;

    private void Start()
    {
        GenarateNote();

    }
    private void DisplayQuestionInPanel(Notes note)
    {
        NoteText.text = note.NoteText;
        NoteTitleText.text = note.NoteTiltleText;
        NotePool.notes.Remove(note);
    }

    private void GenarateNote()
    {

        int randomIndex = Random.Range(0, NotePool.notes.Count);

        
        Notes randomNote =  NotePool.notes[randomIndex];
        usedFlav.usedNotes.Add(randomNote);
        
        randomNote.isCalled = true;

        // Display the quiz question in the quiz panel
        DisplayQuestionInPanel(randomNote);

    }
}

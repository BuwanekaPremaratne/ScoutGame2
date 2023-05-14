using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogPanelManager : MonoBehaviour
{

    public Button buttonPrefab;
    public GameObject NotePrefab;
    public GameObject Notes;

    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {


        foreach (Notes note in usedFlav.usedNotes)
        {
            Button newButton = Instantiate(buttonPrefab);
            newButton.transform.SetParent(transform);

            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = note.NoteTiltleText; // Set the text to the note's title

            // Add an OnClick listener to the button
            newButton.onClick.AddListener(() => DisplayNoteText(note));

        }

        void DisplayNoteText(Notes note)
        {
            Notes.SetActive(false);

            // Access the text component of the note panel prefab
            GameObject NoteObject = Instantiate(NotePrefab);
            NoteObject.transform.SetParent(Panel.transform);
            NoteObject.transform.localPosition = new Vector3(0, -45, 0);
            Debug.Log("NoteObject :"+NoteObject);

            // Access the title and text components of the note panel prefab
            // TextMeshProUGUI titleText = NoteObject.GetComponentInChildren<TextMeshProUGUI>(tag: "Title");
            // TextMeshProUGUI noteText = NoteObject.GetComponentInChildren<TextMeshProUGUI>(tag: "Note");


            // Set the text of the note panel
            // noteText.text = note.text;

            // // Display the note panel
            // notePanelPrefab.SetActive(true);
        }







    }

}

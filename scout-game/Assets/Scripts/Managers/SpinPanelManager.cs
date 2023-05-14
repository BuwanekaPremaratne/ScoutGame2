using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinPanelManager : MonoBehaviour
{
    public GameObject gameBoardPanel; // reference to the game board panel
    public GameObject spinWheelPanel; // reference to the spin wheel panel
    private PlayerMove playerMovement; // reference to the player movement script
    public Button NavSpinWheel; // reference to the Spin Wheel Image Button button
    public Button spinButton;

    private SpinWheel spinWheel;// Refference to SpinWheel Class

    public GameObject QuestPrefab; // the prefab for blue tiles
    public GameObject EventPrefab; // the prefab for green tiles
    public GameObject NotePrefab; // the prefab for orange tiles

    private GridManager GridManager;

    public GameObject Content;

    private Stack<GameObject> panelStack = new Stack<GameObject>();
    public Stack<GameObject> NewpanelStack = new Stack<GameObject>();//to store the panels 

    public EventPanelClose eventClose;
    




    void Start()
    {
        
        playerMovement = GameObject.FindObjectOfType<PlayerMove>();
        // add onClick listener to the spin button
        NavSpinWheel.onClick.AddListener(SpinWheelPanelOpen);
        spinWheel = FindObjectOfType<SpinWheel>();

        GridManager = FindObjectOfType<GridManager>();
        eventClose = FindObjectOfType<EventPanelClose>();
        if (eventClose == null)
        {
            Debug.LogError("Failed to find EventPanelClose component.");
        }
    }


    public void SetNumberOfMoves(int prizeId)
    {
        //Set the number of moves 
        int numberOfMoves = prizeId;

        // start the game
        playerMovement.StartTurn(numberOfMoves);
    }

    public void SpinWheelPanelOpen()
    {

        // Open the spin wheel panel
        spinWheelPanel.SetActive(true);

        // Close the game board panel
        gameBoardPanel.SetActive(false);

    }
    public void ActivateSpinButton()
    {
        spinButton.interactable = true;
        if (spinButton.interactable)
        {
            Debug.Log($"Spin button Activated{spinButton.interactable}");
        }
    }

    public void InstantiatePanel(Color tileColor)
    {
        Color Quest = GridManager.blueColor;
        Color Event = GridManager.greenColor;
        Color Note = GridManager.orangeColor;
        Debug.Log("Quest:" + Quest);
        Debug.Log("Event:" + Event);
        Debug.Log("Note:" + Note);


        Color NewQuestColr = new Color(Quest.r, Quest.g, Quest.b, 1f);
        Color NewEventColor = new Color(Event.r, Event.g, Event.b, 1f);
        Color NewNoteColor = new Color(Note.r, Note.g, Note.b, 1f);


        Debug.Log("Color of the Tile:" + tileColor);
        Transform contentTransform = transform.Find("Content");


        //Ini=staniate the panels according to the color of the tile 
        if (tileColor == NewQuestColr)
        {
            ShowPanel(QuestPrefab);

        }
        else if (tileColor == NewEventColor)
        {
            ShowPanel(EventPrefab);
        }
        else if (tileColor == NewNoteColor)
        {
            ShowPanel(NotePrefab);
        }
        else
        {
            Debug.Log("No maching Color");
        }

    }

    public void ShowPanel(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is null");
            return;
        }

        Debug.Log("Showing Panel");
        GameObject panel = Instantiate(prefab, transform);


        //check panelStack
        Debug.Log(" list before push ;" + panelStack);

        // panelStack.Push(panel);
        // Debug.Log("prfab :" + prefab + " gameObject :" + panel + " and list ;" + panelStack);
        // Debug.Log("panelStack count :" + panelStack.Count);


        gameBoardPanel.SetActive(false);
        Debug.Log(panel + "GamePanel" + gameBoardPanel);

        
        // Close the panel after a delay
        // StartCoroutine(ClosePanel(panel));


    }

    // IEnumerator ClosePanel(GameObject panel)
    // {
    //     yield return new WaitForSeconds(35); // Change the delay time as needed
    //      Destroy(panel);
    //      gameBoardPanel.SetActive(value: true);
    // }

    public void ShowGamebord()
    {
        gameBoardPanel.SetActive(value: true);
    }




    // void OnDisable()
    // {
    //     // end the game when the spin wheel panel is closed
    //     playerMovement.EndGame();
    // }
}
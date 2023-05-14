using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Transform[] tiles; // an array of tile Transforms
    private int numberOfMoves = 0; // number of moves to make

    private int currentMove = 0; // current move count
    private int currentTileIndex = 0; // current tile index
    private Vector3 destination; // destination position for the player

    public float moveSpeed = 1000f;  // speed of the player's movement
    private bool gameInProgress = false; // flag to indicate whether the game is currently in progress
    private Vector3 StartTile;

    SpinPanelManager SpinPanelManager;

    private sceneManager _sceneManager;



    void Start()
    {  
        _sceneManager = GameObject.FindObjectOfType<sceneManager>();

        // set the starting tile as the first destination
        destination = tiles[currentTileIndex].position;
        StartTile = destination;

        SpinPanelManager = FindObjectOfType<SpinPanelManager>();
        Debug.Log("Curruntly in "+currentTileIndex);

    }

    void Update()
    {

        if (gameInProgress && (currentMove < numberOfMoves))
        {
            // move the player towards the destination
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);
            // Debug.Log("Moveing" + numberOfMoves);


            // if the player has reached the destination, select a new one
            if (transform.position == destination)
            {
                // get the color of the current tile
                    Color tileColor = tiles[currentTileIndex].GetComponent<Image>().color;
                    // Debug.Log("Currunt Tile :"+currentTileIndex+" and Tile Color:"+tileColor);
                    // Debug.Log("Number of MOves"+numberOfMoves+ "and Current number :"+currentTileIndex);

                    int newCurrentMove=currentMove;
                    
                    

                // move to the next tile in the array
                currentTileIndex = (currentTileIndex + 1) % tiles.Length;
                destination = tiles[currentTileIndex].position;
                newCurrentMove++;

                if (newCurrentMove== numberOfMoves)
                {
                    Debug.Log("moved to the number");
                    newCurrentMove=0;
                    
                    SpinPanelManager.InstantiatePanel(tileColor);
                }

                //Stop if the player reach the end
                if (destination == StartTile)
                {
                    Debug.Log("Reach the End");
                    EndGame();
                }
                else
                {
                    currentMove++;
                    // currentMove++;
                    // Debug.Log("CurrentMove" + currentMove);
                    // Debug.Log("Current tile" + currentTileIndex);
                    // Debug.Log("destination:" + destination);
                }

            }
        }

    }

    //move the player object
    public void StartTurn(int moves)
    {
        numberOfMoves = moves;
        Debug.Log($"move = {moves}");
        currentMove = 0;

        // set game in progress flag to true
        gameInProgress = true;
    }

    public void EndGame()
    {
        // set game in progress flag to false
        gameInProgress = false;
        _sceneManager.Play();
        



        // save player progress
        SavePlayerProgress();
    }



    private void SavePlayerProgress()
    {
        // save current move count and position to PlayerPrefs
        PlayerPrefs.SetInt("CurrentMoveCount", currentMove);
        PlayerPrefs.SetFloat("PlayerPositionX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", transform.position.z);
    }

    private void LoadPlayerProgress()
    {
        // load current move count and position from PlayerPrefs
        currentMove = PlayerPrefs.GetInt("CurrentMoveCount", 0);
        float playerPositionX = PlayerPrefs.GetFloat("PlayerPositionX", 0f);
        float playerPositionY = PlayerPrefs.GetFloat("PlayerPositionY", 0f);
        float playerPositionZ = PlayerPrefs.GetFloat("PlayerPositionZ", 0f);
        transform.position = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
    }


}


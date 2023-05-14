using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public List<GameObject> tiles = new List<GameObject>(); // references to the 21 tiles 
    public Color blueColor; // Blue color-quiz
    public Color greenColor; // Green color-Event
    public Color orangeColor; // Orrange color-note
    private PlayerStats playerManager;

    private void Start()
    {
        StatManager statManager = FindObjectOfType<StatManager>();

        if (statManager == null)
        {
            Debug.LogError("StatManager is not assigned.");
            return;
        }


        List<Color> tileColors = new List<Color>();

        // Assign random colors to the tiles
        for (int i = 0; i < tiles.Count; i++)
        {
            Color color;
            // int randomNum = Random.Range(0, 3); // Generate a random number 

            

            int randomNum = TileGenerator.GenerateTile(PlayerStats.playerStat, PlayerStats.playerExp);
            Debug.Log(randomNum);

            if (randomNum == 1)
            {
                color = blueColor;// Event
            }
            else if (randomNum == 2)
            {
                // color = blueColor;
                color = greenColor;// quiz
            }
            else
            {
                // color = orangeColor;
                color = greenColor;//note
            }
            tileColors.Add(color);

            // Debug.Log("Tile " + i + " assigned color " + color);
        }

        // Assign the colors to the tiles
        for (int i = 0; i < tiles.Count; i++)
        {
            Color newColor = new Color(tileColors[i].r, tileColors[i].g, tileColors[i].b, 1f);
            tiles[i].GetComponent<Image>().color = newColor;

            // Debug.Log("Tile " + i + " color set to " + tileColors[i]);
        }

        Debug.Log("Color assignment complete");
    }
}
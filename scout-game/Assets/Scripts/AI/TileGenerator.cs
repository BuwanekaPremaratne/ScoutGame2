using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileGenerator
{
    public static int GenerateTile(Dictionary<string, int> playerStats, int playerExp)
    {
        // Define the probabilities of each tile type based on player stats and experience level
        double event_prob = 0.2; // Probability of an event tile
        double quiz_prob = 0.3;  // Probability of a quiz tile
        double note_prob = 0.7;  // Probability of a note tile

        // Calculate the total stats and adjust the probabilities of getting a quiz or an event
        int total_stats = 0;
        foreach (KeyValuePair<string, int> stat in playerStats)
        {
            total_stats += stat.Value;
            
        }
        Debug.Log("total stats :"+total_stats);

        if (total_stats > 0)
        {
            // Adjust the probability of getting a quiz based on total stats
            quiz_prob *= Math.Max(0, 1 - total_stats / 80.0);

            // Adjust the probability of getting an event based on total stats and experience
            // double event_multiplier = (1 + playerExp / 1000.0) * (total_stats / 80.0);
            // Debug.Log("event_multiplier:"+event_multiplier);
            event_prob *= Math.Max(0, 1 - playerExp / 1000.0);

             Debug.Log("quiz_prob:"+quiz_prob);
             Debug.Log("event_prob:"+event_prob);
        }

        // Calculate the probability of getting a note tile
        note_prob *= 1 - (event_prob + quiz_prob);
        Debug.Log("note_prob:"+note_prob);

        // Generate a random number between 1 and 3 to determine the tile type
        System.Random rand = new System.Random();
        double rand_num = rand.NextDouble();
        Debug.Log("rand_num:"+rand_num);

        int tile_type;
        if (rand_num < event_prob)
        {
            tile_type = 1; // Event tile
        }
        else if (rand_num < event_prob + quiz_prob)
        {
            tile_type = 2; // Quiz tile
        }
        else
        {
            tile_type = 3; // Note tile
        }

        // Return the tile type
        Debug.Log("tile_type:"+tile_type);
        return tile_type;
    }
}


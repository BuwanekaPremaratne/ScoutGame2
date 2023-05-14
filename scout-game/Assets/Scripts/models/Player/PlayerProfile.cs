using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player
{
    public string PLayerName;
    public int PlayerAge;
    public string PlayerGender;
    public string PlayerCountry;
    public string PlayerCity;
    public int PlayerLevel;
    public int PlayerExperience;
    public Player(string name, int age, string gender, string country, string city, int experience, int expLevel)
    {
        this.PLayerName = name;
        this.PlayerAge = age;
        this.PlayerGender = gender;
        this.PlayerCountry = country;
        this.PlayerCity = city; 
        this.PlayerExperience = experience;
        this.PlayerLevel = expLevel;
    }

    public override string ToString()
    {
        return PLayerName + ", " + PlayerAge + ", " + PlayerGender + ", " + PlayerCountry + ", " + PlayerCity + ", " + PlayerLevel + ", " + PlayerExperience;
    }

}



public class PlayerProfile : MonoBehaviour
{
    private Player currentPlayer;


    public void CreatePlayer(string name, int age, string gender, string country, string city, int experience, int expLevel)
    {


        // Create a new player model and assign the input values
        Player newPlayer = new Player(name, age, gender, country, city, experience, expLevel);

        // Save the new player model
        currentPlayer = newPlayer;
        Debug.Log("New player created: " + newPlayer.ToString());
    }



    public void SavePlayer()
    {
        // Save the current player model to disk or database
       
        PlayerPrefs.SetString("PlayerName", currentPlayer.PLayerName);
        PlayerPrefs.SetInt("PlayerAge", currentPlayer.PlayerAge);
        PlayerPrefs.SetString("PlayerGender", currentPlayer.PlayerGender);
        PlayerPrefs.SetString("PlayerCountry", currentPlayer.PlayerCountry);
        PlayerPrefs.SetString("PlayerCity", currentPlayer.PlayerCity);
        PlayerPrefs.SetInt("PlayerLevel", currentPlayer.PlayerLevel);
        PlayerPrefs.SetInt("PlayerExperience", currentPlayer.PlayerExperience);
        PlayerPrefs.Save();

        Debug.Log("Player saved to disk.");
    }
}


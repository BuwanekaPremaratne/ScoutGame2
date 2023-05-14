using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerDetails : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField ageInputField;
    public Toggle maleToggle;
    public Toggle femaleToggle;
    public TMP_Dropdown countryDropdown;
    public TMP_Dropdown cityDropdown;
    public PlayerProfile playerProfile;

    public void OnProceedButtonClick()
    {
        // Check if required fields are filled
        if (string.IsNullOrEmpty(nameInputField.text) || string.IsNullOrEmpty(ageInputField.text))
        {
            Debug.Log("Please fill in all required fields.");
            return;
        }
        if (!maleToggle.isOn && !femaleToggle.isOn)
        {
            Debug.Log("Please select a gender.");
            return;
        }
        if (countryDropdown.value == 0 || cityDropdown.value == 0)
        {
            Debug.Log("Please select a country and city.");
            return;
        }

        // Create a new player model
        string name = nameInputField.text;
        int age = int.Parse(ageInputField.text);
        string country = countryDropdown.options[countryDropdown.value].text;
        string city = cityDropdown.options[cityDropdown.value].text;
        string gender = maleToggle.isOn ? "Male" : "Female";
        int experience=0;
        int expLevel=0;
        playerProfile.CreatePlayer(name, age, gender, country, city,experience,expLevel);

        // Save the new player model
        // playerProfile.SavePlayer();
    }
}
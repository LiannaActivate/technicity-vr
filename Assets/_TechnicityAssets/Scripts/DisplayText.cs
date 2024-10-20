using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TMP_Text obj_text;          // Reference to the text object in Canvas NameConfirmation
    public TMP_InputField inputField;  // Reference to the input field in Canvas EnterName


    void Start()
    {
        // Load the saved username if it exists and update the text
        obj_text.text = PlayerPrefs.GetString("user_name", ""); // Default to empty if not set

        // Add listener for input field changes
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    void OnInputValueChanged(string newValue)
    {
        // Update PlayerPrefs with the new input value
        PlayerPrefs.SetString("user_name", newValue);
        PlayerPrefs.Save();

        // Update the text in Canvas B immediately
        obj_text.text = newValue;
    }
}
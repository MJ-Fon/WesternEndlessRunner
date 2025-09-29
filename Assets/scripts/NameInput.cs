using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameInput : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        // Show current name in field
        inputField.text = PlayerSettings.PlayerName;
    }

    // Hook this to InputField’s OnValueChanged event
    public void OnNameChanged(string newName)
    {
        if (!string.IsNullOrWhiteSpace(newName))
        {
            PlayerSettings.PlayerName = newName;
            Debug.Log("Player name saved: " + newName);
        }
    }

    public void ConfirmName()
    {
        string newName = inputField.text.Trim();

        if (!string.IsNullOrEmpty(newName))
        {
            PlayerSettings.PlayerName = newName;
            PlayerPrefs.Save(); // make sure it's written to disk immediately
            Debug.Log("Player name confirmed: " + newName);
        }
    }
}

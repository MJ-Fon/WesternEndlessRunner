using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviour
{
    public TMP_Text nameText;
    public string prefix = ""; // optional text before the name

    void Start()
    {
        if (nameText != null)
        {
            nameText.text = prefix + PlayerSettings.PlayerName;
        }
    }

    void OnEnable()
    {
        if (nameText != null)
        {
            nameText.text = prefix + PlayerSettings.PlayerName;
        }
    }
}

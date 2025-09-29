using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings
{
    public static string PlayerName
    {
        get => PlayerPrefs.GetString("PlayerName", "Alex"); // default "Alex"
        set => PlayerPrefs.SetString("PlayerName", value);
    }
}
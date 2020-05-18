using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimesInMenu : MonoBehaviour
{
    /// <summary>
    /// Here we clear the ammount of times the user has accessed the main menu,
    /// for ad purposes
    /// </summary>
    /// 

    void Start()
    {
        PlayerPrefs.SetInt("timesInMainMenu", 0);
    }
}

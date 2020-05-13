using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameHandler : MonoBehaviour
{
    string username { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            username = PlayerPrefs.GetString("username");
        }
        else
        {
            username = "ANONY";
        }
    }

    private void Start()
    {
        GetComponentInChildren<InputField>().text = username;
    }
    public void SetUsername(string username)
    {
        PlayerPrefs.SetString("username", username);
    }

    public string GetUsername()
    {
        return username;
    }

    public void UpdateUsername()
    {
        SetUsername(GetComponentInChildren<InputField>().text);
    }
}

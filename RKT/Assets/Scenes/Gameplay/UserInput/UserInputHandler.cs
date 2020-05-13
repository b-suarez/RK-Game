using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputHandler : MonoBehaviour
{
    UsernameHandler usernameHandler;
    // Start is called before the first frame update
    public void updatePlaceholder(string placeholder)
    {
        GetComponent<InputField>().text = placeholder;
    }
}

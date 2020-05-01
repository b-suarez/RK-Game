using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimerText : MonoBehaviour {
    Text textField;
	// Use this for initialization
	void Start () {
        textField = GetComponent<Text>();
	}

	public void updateMainTimerText(float timeLeft)
	{
		textField.text = timeLeft.ToString("F1"); ;
	}
}

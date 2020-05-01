using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalModeMainTimerText : MonoBehaviour
{
	Text textField;
	// Use this for initialization
	void Start()
	{
		textField = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		textField.text = GetComponentInParent<SurvivalModeTimerController>().roundTimeLeft.ToString("F0"); ;
	}
}

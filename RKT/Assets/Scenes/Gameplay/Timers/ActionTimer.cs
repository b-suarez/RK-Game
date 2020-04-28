using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionTimer : MonoBehaviour {

	Text text;
	private void Start()
	{
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void FixedUpdate () {
       text.text = GetComponentInParent<TimerController>().getActionTimeLeft().ToString("F1");
	}
}

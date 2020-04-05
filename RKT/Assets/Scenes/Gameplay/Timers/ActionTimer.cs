using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionTimer : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = GetComponentInParent<TimerController>().getActionTimeLeft().ToString();
	}
}

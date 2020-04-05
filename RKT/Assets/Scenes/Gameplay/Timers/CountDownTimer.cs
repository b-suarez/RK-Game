using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

    public bool countdownIsShown;
    TimerController timerController;

	// Use this for initialization
	void Start () {
        timerController = GetComponentInParent<TimerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (countdownIsShown)
        {
            GetComponent<Text>().text = timerController.getCountdownTimerLeft().ToString();
        }
        else
        {
            GetComponent<Text>().text = "";
        }
        
    }

    public void activate()
    {
        countdownIsShown = true;
        Debug.Log("TEST");
    }

    public void deactivate()
    {
        countdownIsShown = false;
    }
}

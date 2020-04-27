using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

    public bool countdownIsShown;
    TimerController timerController;
    Animator animator;

	// Use this for initialization
	void Start () {
        timerController = GetComponentInParent<TimerController>();
      
	}
	
	// Update is called once per frame
	void Update () {
        if (countdownIsShown)
        {
            GetComponentInChildren<Text>().text =Mathf.Ceil(timerController.getCountdownTimerLeft()).ToString(); 
        }
        else
        {
            GetComponentInChildren<Text>().text = "";
        }
    }

    public void activate()
    {
        countdownIsShown = true;
        gameObject.GetComponent<Animator>().SetTrigger("countdown-starts");
    }

    public void deactivate()
    {
        countdownIsShown = false;
    }
}

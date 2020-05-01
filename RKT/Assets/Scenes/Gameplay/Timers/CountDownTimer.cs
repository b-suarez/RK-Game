using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

    public bool countdownIsShown;
    Animator animator;

    public void activate()
    {
        countdownIsShown = true;
        gameObject.GetComponent<Animator>().SetTrigger("countdown-starts");
    }

    public void deactivate()
    {
        countdownIsShown = false;
    }

    public void updateCountdownTimer(float timeLeft)
    {
        GetComponentInChildren<Text>().text = Mathf.Ceil(timeLeft).ToString();
    }
}

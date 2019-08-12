using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTImer : MonoBehaviour {
    bool timerStarted;
    bool hasfinished;
    bool transitionDisplayed;
    float secondsLeft;

    public GameObject transitionsManager;
    // Use this for initialization
    void Start () {
        secondsLeft = 5.49f;
	}
	
	// Update is called once per frame
	void Update () {

        if (secondsLeft <= 1 && !hasfinished)
        {
             
            GetComponent<Text>().text = (" ");
            hasfinished = true;
            GetComponentInParent<GameController>().StartGameplay();
        }
        if (timerStarted && !hasfinished)
        {
            secondsLeft = secondsLeft - Time.deltaTime;
            if (secondsLeft <= 1.5f && !transitionDisplayed)
            {
                transitionsManager.GetComponent<UITransitions>().PlayUITransition();
                transitionDisplayed = true;
            }
            GetComponent<Text>().text = secondsLeft.ToString("0");
        }
        
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    
}

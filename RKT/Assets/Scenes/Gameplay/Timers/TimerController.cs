using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour {

    GameController controller;
    CountDownTimer countDownTimerItem;
    float roundTime = 30.0f;
    float actionTime = 10.0f;
    float countDownTime = 3.0f;
    TimerText mainTimer;    public float roundTimeLeft; float actionTimeLeft;
    float countDownTimerLeft;
    bool roundTimeHasStarted, timerIsOver;
    bool countDownTimerIsOver;
    bool isPaused;


	// Use this for initialization
	void Start () {
        controller = GetComponent<GameController>();
        countDownTimerItem = GetComponentInChildren<CountDownTimer>();

        isPaused = false;

        roundTimeLeft = roundTime;
        actionTimeLeft = actionTime;

        roundTimeHasStarted = false;
        timerIsOver = false;

        startCountDownTimer();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isPaused== false)
        {
            countDownTimer();
            if (roundTimeHasStarted && !timerIsOver)
            {
                roundTimeLeft -= Time.deltaTime;

                actionTimeLeft -= Time.deltaTime;

                if (actionTimeLeft <= 0)
                {
                    controller.roundOver();
                }

                if (roundTimeLeft <= 0)
                {
                    controller.GameOver();
                    timerIsOver = true;
                }
            }
        }
    }

    void startRoundTimer()
    {
        roundTimeHasStarted = true;
    }

    public void restartActionTimer()
    {
        actionTimeLeft = actionTime;
    }

    public void restartTimers()
    {
        roundTimeLeft = roundTime;
        restartActionTimer();
        timerIsOver = false;
    }

    public float getActionTimeLeft()
    {
        return actionTimeLeft;
    }

    public void startCountDownTimer()
    {
        countDownTimerIsOver = false;
        countDownTimerLeft = countDownTime;
        countDownTimerItem.activate();
    }

    public void countDownTimer()
    {
        if (countDownTimerLeft <= 0 && !controller.gameplayHasStarted)
        {
            controller.startGameplay();
            startRoundTimer();
            countDownTimerItem.deactivate();
        }
        else if(!controller.gameplayHasStarted)
        {
            countDownTimerLeft -= Time.deltaTime;
        }
    }

    public float getCountdownTimerLeft()
    {
        return countDownTimerLeft;
    }

    public void pauseTimer()
    {
        isPaused = !isPaused;
    }
}

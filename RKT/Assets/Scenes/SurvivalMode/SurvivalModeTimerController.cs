using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalModeTimerController : MonoBehaviour
{

    SurvivalModeController controller;
    
    CountDownTimer countDownTimerItem;

    MainTimerText mainTimerText;
    SurvivalModeTotalTimerText survivalModeTotalTimerText;

    float roundTime = 10.0f;
    float totalTime;
    float countDownTime = 3.0f;
    TimerText mainTimer; public float roundTimeLeft; 
    float countDownTimerLeft;
    bool roundTimeHasStarted, timerIsOver;
    bool countDownTimerIsOver;
    bool isPaused;
    float longestSurvivalGame;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<SurvivalModeController>();
        countDownTimerItem = GetComponentInChildren<CountDownTimer>();
        mainTimerText = GetComponentInChildren<MainTimerText>();
        survivalModeTotalTimerText = GetComponentInChildren<SurvivalModeTotalTimerText>();

        isPaused = false;

        roundTimeLeft = roundTime;

        roundTimeHasStarted = false;
        timerIsOver = false;

        longestSurvivalGame = PlayerPrefs.GetFloat("LongestSurvivalGame");

        startCountDownTimer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isPaused == false)
        {
            if (!countDownTimerIsOver)
            {
                countDownTimer();
            }
            
            if (roundTimeHasStarted && !timerIsOver)
            {
                roundTimeLeft -= Time.deltaTime;
                totalTime += Time.deltaTime;
                mainTimerText.updateMainTimerText(roundTimeLeft);
                survivalModeTotalTimerText.updateTotalTimerText(totalTime);

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

    public void restartTimers()
    {
        roundTimeLeft = roundTime;
        timerIsOver = false;
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
        else if (!controller.gameplayHasStarted)
        {
            countDownTimerLeft -= Time.deltaTime;
            GetComponentInChildren<CountDownTimer>().updateCountdownTimer(countDownTimerLeft);
        }
    }

    public float getCountdownTimerLeft()
    {
        return countDownTimerLeft;
    }

    public float getTotalTime()
    {
        return totalTime;
    }

    public void addTimeToMainTimer(int secondsToAdd)
    {
        roundTimeLeft = roundTimeLeft + secondsToAdd;
        mainTimerText.updateMainTimerText(roundTimeLeft);
    }

    public void pauseTimer()
    {
        isPaused = !isPaused;
    }
}

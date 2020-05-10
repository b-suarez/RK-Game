using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {
    int isFirstTime;
    StepScript[] stepsArray;
    int currentStep;
    bool firstActionItemClicked;
    bool centerItemActiveFirstTime;
    bool centerItemClickedFirstTime;

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            PlayerPrefs.SetInt("isFirstTime", 0);
            PlayerPrefs.SetInt("isFirstTimeSurvival", 0);
            PlayerPrefs.SetFloat("LongestSurvivalGame",0);
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public void startTutorial()
    {
        stepsArray = GetComponentsInChildren<StepScript>();
        currentStep = 0;
        stepsArray[currentStep].activate();
    }

    public void deactivateStep(int stepToDeactivate)
    {
        stepsArray[stepToDeactivate].deactivate();
    }

    public void activateNextStep()
    {
        deactivateStep(currentStep);

        if(currentStep < stepsArray.Length-1)
        {
            currentStep++;
            stepsArray[currentStep].activate();
        }
        
    }

    public void actionItemClicked()
    {
        if (!firstActionItemClicked)
        {
            activateNextStep();
            firstActionItemClicked = true;
        } 
    }

    public void centerItemActivated()
    {
        if (!centerItemActiveFirstTime)
        {
            activateNextStep();
            centerItemActiveFirstTime = true;
        }
    }

    public void centerItemClicked()
    {
        if (!centerItemClickedFirstTime)
        {
            activateNextStep();
            centerItemClickedFirstTime = true;
        }
    }

    public void tutorialFinished()
    {
        PlayerPrefs.SetInt("isFirstTime",1);
    }

    public void tutorialSurvivalFinished()
    {
        PlayerPrefs.SetInt("isFirstTimeSurvival", 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    Animator animatorController;
    public int scoreToDisplay, highScoreToDisplay;

    public void triggerGameOverMenu(int score, int highScore)
    {
        scoreToDisplay = score;
        highScoreToDisplay = highScore;

        animatorController = gameObject.GetComponent<Animator>();
        animatorController.SetTrigger("trigger-activation");
    }
}

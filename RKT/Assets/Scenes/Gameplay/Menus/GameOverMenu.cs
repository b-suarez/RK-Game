using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    Animator animatorController;
    ScoreText scoreText;
    HighScoreText highScoreText;
    public int scoreToDisplay, highScoreToDisplay;

    public void triggerGameOverMenu(int score, int highScore)
    {
        scoreToDisplay = score;
        highScoreToDisplay = highScore;

        scoreText = GetComponentInChildren<ScoreText>();
        scoreText.setScoreText(scoreToDisplay);

        highScoreText = GetComponentInChildren<HighScoreText>();
        highScoreText.setHighScore(highScoreToDisplay);

        animatorController = gameObject.GetComponent<Animator>();
        animatorController.SetTrigger("trigger-activation");
    }
}

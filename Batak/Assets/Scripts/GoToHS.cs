using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToHS : MonoBehaviour {
    public void GoToHighScore()
    {
        SceneManager.LoadScene("HighScoreScreen");
    }

    public void GoToSurvival()
    {
        SceneManager.LoadScene("Survival");
    }
}

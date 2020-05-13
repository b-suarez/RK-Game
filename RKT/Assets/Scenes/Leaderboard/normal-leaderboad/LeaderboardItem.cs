using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardItem : MonoBehaviour {
    ScoreTextController scoreTextController;
    UsernameTextController usernameTextController;

    // Start is called before the first frame update
    void Awake()
    {
        scoreTextController = GetComponentInChildren<ScoreTextController>();
        usernameTextController = GetComponentInChildren<UsernameTextController>();
    }

    public void SetUsernameAndScoreTexts(string username, string score)
    {
        scoreTextController.updateText(score);
        usernameTextController.updateText(username);
    }
}

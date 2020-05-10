using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    SurvivalModeBestTimeText bestTimeTimeTrialText;
    HighScoreText highScoreText;

    // Animator Booleans:
    // - timeTrialSelected;

    Animator leaderboardAnimator;

    private void Awake()
    {
        bestTimeTimeTrialText = GetComponentInChildren<SurvivalModeBestTimeText>();
        highScoreText = GetComponentInChildren<HighScoreText>();
        leaderboardAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LongestSurvivalGame")){
            bestTimeTimeTrialText.setBestTimeText(PlayerPrefs.GetFloat("LongestSurvivalGame"));
        }
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.setHighScore(PlayerPrefs.GetInt("HighScore"));
        }
        Debug.Log(PlayerPrefs.GetInt("HighScore").ToString() + " " + PlayerPrefs.GetFloat("LongestSurvivalGame").ToString());
       
    }

    public void triggerTimeTrialLeaderboard()
    {
        leaderboardAnimator.SetBool("timeTrialSelected", true);
    }
    public void triggerNormalModeLeaderboard()
    {
        leaderboardAnimator.SetBool("timeTrialSelected", false);
    }
}

using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using SimpleJSON;
public class LeaderboardController : MonoBehaviour
{
    SurvivalModeBestTimeText bestTimeTimeTrialText;
    HighScoreText highScoreText;

    public class ScoreBoard
    {
        Dictionary<string, ScoreSaveController[]> scores;
    }

    private FirebaseDatabase _database;

    // Animator Booleans:
    // - timeTrialSelected;

    Animator leaderboardAnimator;
    ScoreBoard testScoreboard;

    private void Awake()
    {
        bestTimeTimeTrialText = GetComponentInChildren<SurvivalModeBestTimeText>();
        highScoreText = GetComponentInChildren<HighScoreText>();
        leaderboardAnimator = GetComponent<Animator>();


        _database = FirebaseDatabase.DefaultInstance;
    }

    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            StartCoroutine(LoadNormalScoreCoroutine());
        }
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
    }

    public void triggerTimeTrialLeaderboard()
    {
        leaderboardAnimator.SetBool("timeTrialSelected", true);
    }
    public void triggerNormalModeLeaderboard()
    {
        leaderboardAnimator.SetBool("timeTrialSelected", false);
    }
    public async Task<ScoreBoard> LoadNormalScoreBoard()
    {
        var dataSnapshot = await _database.GetReference("scores/normal/").GetValueAsync();
        if (!dataSnapshot.Exists)
        {
            return null;
        }
        var test = JSON.Parse(dataSnapshot.GetRawJsonValue());
        string lool = test[0]["username"].Value;
        string tas = test[1]["username"].Value;
 
        //var test = JsonUtility.FromJson<Dictionary<string, ScoreSaveController[]>>(dataSnapshot.GetRawJsonValue());



        return JsonUtility.FromJson<ScoreBoard>(dataSnapshot.GetRawJsonValue());
    }

    private IEnumerator LoadNormalScoreCoroutine()
    {
        var loadScoresTask = LoadNormalScoreBoard();
        yield return new WaitUntil(() => loadScoresTask.IsCompleted);
        testScoreboard = loadScoresTask.Result;
    }
}

using Firebase.Database;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static SurvivalScoreSavingController;

public class SurvivalLeaderboardController : MonoBehaviour
{
    LeaderboardItem[] leaderboardItems;
    private FirebaseDatabase _database;

    public class SurvivalScoreBoard
    {
        Dictionary<string, ScoreSaveController[]> scores;
    }

    void Awake()
    {
        leaderboardItems = GetComponentsInChildren<LeaderboardItem>();
    }

    private void Start()
    {
        //Initialize a default instance of the Firebase Database
        _database = FirebaseDatabase.DefaultInstance;

        // Start kiadubg the scores
        StartCoroutine(LoadSurvivalScoresCoroutine());
    }

    public async Task<SurvivalScoreBoard> LoadSurvivalScoreBoard()
    {
        var dataSnapshot = await _database.GetReference("scores/survival/").GetValueAsync();
        if (!dataSnapshot.Exists)
        {
            return null;
        }
        var scores = JSON.Parse(dataSnapshot.GetRawJsonValue());

        Dictionary<int, SurvivalModeScore> highestValues = new Dictionary<int, SurvivalModeScore>();
        for (int i = 0; i < leaderboardItems.Length; i++)
        {
            SurvivalModeScore highScore = new SurvivalModeScore("ANONYM", 0);
            int highestCurrentScore = 0;

            for (int j = 0; j < scores.Count; j++)
            {
                if (scores[j]["score"] >= highScore.score)
                {
                    highestCurrentScore = j;
                    highScore.score = scores[j]["score"];
                    highScore.username = scores[j]["username"];
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////
            ////When obtained a max value, we add it to the highest values dictionary
            ///and remove it from the total scores list

            highestValues.Add(i, highScore);
            scores.Remove(highestCurrentScore);
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //Go through the Leaderboard Items and assign it the sorted values obtained before

        for (int i = 0; i < leaderboardItems.Length; i++)
        {
            leaderboardItems[i].SetUsernameAndScoreTexts(
               highestValues[i].username.ToUpper(),
               highestValues[i].score.ToString("F0") + "''"
               );
        }

        return JsonUtility.FromJson<SurvivalScoreBoard>(dataSnapshot.GetRawJsonValue());
    }

    private IEnumerator LoadSurvivalScoresCoroutine()
    {
        var loadScoresTask = LoadSurvivalScoreBoard();
        yield return new WaitUntil(() => loadScoresTask.IsCompleted);
    }
}

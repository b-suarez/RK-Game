using Firebase.Database;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static NormalScoreSavingController;

public class NormalLeaderBoardController : MonoBehaviour
{
    LeaderboardItem[] leaderboardItems;
    private FirebaseDatabase _database;

    public class NormalScoreBoard
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
        StartCoroutine(LoadNormalScoresCoroutine());
    }

    public async Task<NormalScoreBoard> LoadNormalScoreBoard()
    {
        var dataSnapshot = await _database.GetReference("scores/normal/").GetValueAsync();
        if (!dataSnapshot.Exists)
        {
            return null;
        }
        var scores = JSON.Parse(dataSnapshot.GetRawJsonValue());

        Dictionary<int,NormalModeScore> highestValues = new Dictionary<int, NormalModeScore>();
        for (int i = 0; i < leaderboardItems.Length; i++)
        {
            NormalModeScore highScore = new NormalModeScore("-", 0);
            int highestCurrentScore = 0;

            for (int j = 0; j < scores.Count; j++)
            {
                if(scores[j]["score"]>= highScore.score)
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
               highestValues[i].score.ToString()
               );
        }

        return JsonUtility.FromJson<NormalScoreBoard>(dataSnapshot.GetRawJsonValue());
    }

    private IEnumerator LoadNormalScoresCoroutine()
    {
        var loadScoresTask = LoadNormalScoreBoard();
        yield return new WaitUntil(() => loadScoresTask.IsCompleted);
    }

}

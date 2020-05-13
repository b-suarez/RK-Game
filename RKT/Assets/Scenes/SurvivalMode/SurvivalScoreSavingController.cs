using Firebase.Database;
using UnityEngine;

public class SurvivalScoreSavingController : MonoBehaviour
{
    UsernameHandler usernameHandler;
    private FirebaseDatabase _database;
    private string username;

    public class SurvivalModeScore
    {
        public string username;
        public float score;

        public SurvivalModeScore(string receivedName, float receivedScore)
        {
            username = receivedName;
            score = receivedScore;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _database = FirebaseDatabase.DefaultInstance;

        usernameHandler = GetComponent<UsernameHandler>();
    }

    public void SaveSurvivalScore(int score)
    {
        SubmitSurvivalScoreToFirebase(usernameHandler.GetUsername(), score);
    }

    public void SubmitSurvivalScoreToFirebase(string playerName, int playerScore)
    {
        SurvivalModeScore score = new SurvivalModeScore(playerName, playerScore);
        _database.GetReference(
            "scores/survival/" + 
            System.DateTime.Now.ToString("yyyyMMddTHH:mm:ssZ") + "-" + playerName
            ).SetRawJsonValueAsync(JsonUtility.ToJson(score));
    }
}

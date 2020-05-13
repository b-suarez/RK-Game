using Firebase.Database;
using UnityEngine;

public class NormalScoreSavingController : MonoBehaviour
{
    UsernameHandler usernameHandler;
    private FirebaseDatabase _database;
    private string username;

    public class NormalModeScore
    {
        public string username;
        public float score;

        public NormalModeScore(string receivedName, int receivedScore)
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

    public void SaveNormalScore(int score)
    {
        SubmitNormalScoreToFirebase(usernameHandler.GetUsername(), score);
    }

    public void SubmitNormalScoreToFirebase(string playerName, int playerScore)
    {
        NormalModeScore player = new NormalModeScore(playerName, playerScore);
        _database.GetReference("scores/normal/" + System.DateTime.Now.ToString("yyyyMMddTHH:mm:ssZ")+"-"+playerName).SetRawJsonValueAsync(JsonUtility.ToJson(player));
    }
}

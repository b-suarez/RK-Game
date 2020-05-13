using Firebase.Database;
using UnityEngine;

public class ScoreSaveController : MonoBehaviour
{
    private FirebaseDatabase _database;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            SaveNormalScoreData("new", 451);
        }
    }

    public void SaveNormalScoreData(string playerName, int playerScore)
    {
        NormalModeScore player = new NormalModeScore(playerName, playerScore);
        _database.GetReference("scores/normal/"+playerName).SetRawJsonValueAsync(JsonUtility.ToJson(player));
    }
}

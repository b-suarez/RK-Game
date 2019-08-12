using UnityEngine;
using UnityEngine.UI;

public class ScoreToShow : MonoBehaviour {
    GameController gameController;
    Text text;
    int scoreToShow;
    int absoluteScore;
	// Use this for initialization
	void Start () {
        gameController = GetComponentInParent<GameController>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        absoluteScore = gameController.score;

        if (absoluteScore / 100 > scoreToShow+1)
        {
            scoreToShow = scoreToShow + 100;
        }

        else if (absoluteScore / 10 > scoreToShow)
        {
            scoreToShow = scoreToShow + 50;
        }
        else if (absoluteScore/4 > scoreToShow)
        {
            scoreToShow  = scoreToShow + 10;
        }
        else if (absoluteScore / 2 > scoreToShow)
        {
            scoreToShow = scoreToShow + 4;
        }
        else if (absoluteScore > scoreToShow)
        {
            scoreToShow = scoreToShow + 1;
        }
        text.text = scoreToShow.ToString();

    }

    public void EndGame()
    {
        text.text = absoluteScore.ToString();
    }

    public void SetScore()
    {
        scoreToShow = absoluteScore;
    }
}

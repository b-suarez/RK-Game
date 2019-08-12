using UnityEngine;

using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
    public GameObject smallTimer;
    public GameObject minuteTimer;
    public GameObject multiplierText;
    public GameObject scoreText;

    public GameObject countDownTimer;


    public GameObject repeatButton;

    GameplaySounds gameplaySounds;

    public int score;

    public bool IsSurvival;
    int multiplier;

    public int scoreToBeat;

    private void Start()
    {
        multiplier = 1;
        GetComponentInChildren<UITransitions>().PlayUITransition();
        gameplaySounds = GetComponent<GameplaySounds>();
        countDownTimer.GetComponent<CountDownTImer>().StartTimer();
        Handheld.Vibrate();

    }


    public void TimeOver()
    {
        GetComponentInChildren<ScoreToShow>().SetScore();
        smallTimer.SetActive(false);
        GetComponentInChildren<ScoreToShow>().EndGame();
        GetComponent<HitPointManager>().BlockButtons();
        EnableRepeatButton();
        GetComponentInChildren<UITransitions>().PlayFinishAnimation();

        scoreToBeat = LoadScoreToBeat();

        if (GetComponentInChildren<ResultLabel>())
        {
            GetComponentInChildren<ResultLabel>().SetScores(scoreToBeat, score);
        }
        

        if (score > scoreToBeat)
        {
            SaveScore();
        }
    }

    public void CenterButtonClicked()
    {
        GetComponentInChildren<ScoreToShow>().SetScore();
        score = score + (int)smallTimer.GetComponent<SmallTimer>().TimeToReset * multiplier*6;
        //ADD Multiplier
        multiplier++;
        //ADD Score

        // Reset Timer
        if (smallTimer)
        {
            smallTimer.GetComponent<SmallTimer>().ResetTimer();
        }

        GetComponentInChildren<ErrorGameplay>().SetCorrectButton();
        gameplaySounds.PlayBigButtonSound();
        Handheld.Vibrate();
        GetComponentInChildren<MultiplierText>().ChangeMultiplier(multiplier.ToString());

        if (IsSurvival)
        {
            minuteTimer.GetComponent<MinuteTimer>().AddSeconds(1);
        }
    }

    public void Error()
    {
        //Reset Multiplier
        //Add Score

        //REset timer
        if (smallTimer)
        {
            smallTimer.GetComponent<SmallTimer>().ResetTimer();
        }
        multiplier = 1;
        GetComponentInChildren<MultiplierText>().ChangeMultiplier(multiplier.ToString());

        GetComponentInChildren<ErrorGameplay>().SetErrorGameplay();

        if (IsSurvival)
        {
            minuteTimer.GetComponent<MinuteTimer>().SubtractSeconds(2);
        }

    }

    public void AddScore(int _score)
    {
        score = score + _score;
    }

    void EnableRepeatButton()
    {
        repeatButton.SetActive(true);
    }

    public void BlockedInterface()
    {
        GetComponentInChildren<ScoreToShow>().EndGame();
        GetComponent<HitPointManager>().BlockButtons();
    }

    public void StartGameplay()
    {
        smallTimer.SetActive(true);
        minuteTimer.SetActive(true);
        multiplierText.SetActive(true);
        scoreText.SetActive(true);

        GetComponentInChildren<MinuteTimer>().StartTimer();
        GetComponent<HitPointManager>().ResetPositionsInSequence();

    }

    public void SaveScore()
    {
        if(File.Exists(Application.persistentDataPath + "/highscore.dat"))
        {
            BinaryFormatter binFor = new BinaryFormatter();
            FileStream existingFile = File.Open(Application.persistentDataPath + "/highscore.dat", FileMode.Open);

            HighScoreData oldHighScore = (HighScoreData)binFor.Deserialize(existingFile);
            existingFile.Close();


            binFor = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/highscore.dat");
            HighScoreData data = new HighScoreData();

            if (IsSurvival)
            {
                data.highScoreSurvival = score;
                data.highScore = oldHighScore.highScore;
            }
            else
            {
                data.highScore = score;
                data.highScoreSurvival = oldHighScore.highScoreSurvival;
            }

            binFor.Serialize(file, data);
            file.Close();
        }
        else {

            BinaryFormatter binFor = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/highscore.dat");
            HighScoreData data = new HighScoreData();

            if (IsSurvival)
            {
                data.highScoreSurvival = score;
                data.highScore = 0;
            }
            else
            {
                data.highScore = score;
                data.highScoreSurvival = 0;
            }

            binFor.Serialize(file, data);
            file.Close();
        }
       
    }

    public int LoadScoreToBeat()
    {
        if (File.Exists(Application.persistentDataPath + "/highscore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscore.dat", FileMode.Open);

            HighScoreData highScoreData = (HighScoreData)bf.Deserialize(file);

            file.Close();

            if (!IsSurvival) {
                return (int)highScoreData.highScore;
            }
            else
            {
                return (int)highScoreData.highScoreSurvival;
            }
            
        }
        else
        {
            return 0;
        }
    } 

    [Serializable]
    public class HighScoreData
    {
        public float highScore;
        public float highScoreSurvival;
    }

}

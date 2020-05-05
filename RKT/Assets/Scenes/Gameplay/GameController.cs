using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    int currentAvailableNumber;
    ClickableItem[] clickableObjects;
    CenterItem centerItem;
    TimerController timerController;
    GameOverMenu gameOverMenu;
    SoundController soundController;
    SoundTrackController soundTrackController;

    ScoreText scoreText;

    int highscore;

    public bool gameplayHasStarted = false;
    int pointsPerCorrect = 100;
    int pointsPerCenter = 500;


    int score;
    int multiplier;

	// Use this for initialization
	void Start () {

        timerController = GetComponent<TimerController>();
        soundController = GetComponent<SoundController>();

        centerItem = GetComponentInChildren<CenterItem>();
        clickableObjects = GetComponentsInChildren<ClickableItem>();
        gameOverMenu = GetComponentInChildren<GameOverMenu>();

        scoreText = GetComponentInChildren<ScoreText>();

        soundTrackController = GetComponentInChildren<SoundTrackController>();

        highscore = PlayerPrefs.GetInt("HighScore");

        soundTrackController.startSoundtrack();
    }

    void setInitialPositions(List<int> positions)
    {
        for (int i = 0; i < clickableObjects.Length; i++)
        {
            clickableObjects[i].SetPositionText(positions[i]);
            if(positions[i] == 0)
            {
                clickableObjects[i].Activate();
            }
        }
    }

    void deactivateAllItems()
    {
        for (int i = 0; i < clickableObjects.Length; i++)
        {
            if (clickableObjects[i].isActiveAndEnabled)
            {
                clickableObjects[i].Deactivate();
            } 
        }
    }

    List<int> getNewPositions()
    {
        List<int> filledPositions = new List<int>();

        for (int i = 0; i < clickableObjects.Length; i++)
        {
            bool filled = false;

            while (!filled)
            {
                int intToAdd = Random.Range(0, clickableObjects.Length);

                if (filledPositions.Count <= 0)
                {
                    filledPositions.Add(intToAdd);
                    filled = true;
                }
                else
                {
                    bool canBeAdded = true;
                    for (int j = 0; j < filledPositions.Count; j++)
                    {
                        if(intToAdd == filledPositions[j])
                        {
                            canBeAdded = false;
                        }
                    }
                    if (canBeAdded)
                    {
                        filledPositions.Add(intToAdd);
                        filled = true;
                    }
                }
            }
        }
        return filledPositions;
    }

    public void clickedPosition(int position)
    {

        
        deactivateItem(position);
        
        addScore(pointsPerCorrect);

        soundController.playAudio(position);

        if (position+1 >= clickableObjects.Length)
        {
            centerItem.activate();

            //CODE PORTION TO SEND INFO TO THE TUTORIAL

            if (isFirstTimeNormalGame())
            {
                GetComponentInChildren<TutorialScript>().centerItemActivated();
            }  

            ///////////////////////////////////////////
        }
        else
        {
            activateNextItem(position);
        }

        //CODE PORTION TO SEND INFO TO THE TUTORIAL

        if (isFirstTimeNormalGame())
        {
            GetComponentInChildren<TutorialScript>().actionItemClicked();
        }

        ///////////////////////////////////////////
    }

    void activateNextItem(int currentItem)
    {
        int activateNextItem = currentItem + 1;
        

       for (int i = 0; i < clickableObjects.Length; i++)
        {
            if (clickableObjects[i].GetPosition() == activateNextItem)
            {
                clickableObjects[i].Activate();
            }
        }
    }

    void deactivateItem(int item)
    {
        for (int i = 0; i < clickableObjects.Length; i++)
        {
            if (clickableObjects[i].GetPosition() == item)
            {
                clickableObjects[i].Deactivate();
            }
        }
    }

    public void GameOver()
    {
        deactivateAllItems();
        gameOverMenu.triggerGameOverMenu(score, highscore);
        soundTrackController.triggerFadeOut();

        if (score > getHighScore())
        {
            setHighScore(score);
        }
    }

    void roundCompleted()
    {
        GetComponentInChildren<MenuAnimations>().playRoundCompletedAnim();
        addScore(pointsPerCenter);
        addMultiplier();
        setInitialPositions(getNewPositions());

        //Restart the action timer each time a round has been completed
        timerController.restartActionTimer();
    }

    public void roundOver()
    {
        GetComponentInChildren<MenuAnimations>().playErrorAnim();

        resetMultiplier();
        resetGameplay();
        timerController.restartActionTimer();

        if (centerItem.isActive())
        {
            centerItem.deactivate();
        }

    }

    void resetScoreAndMultiplier()
    {
        score = 0;
        resetMultiplier();
    }

    void addScore(int pointsToAdd)
    {
        score = score + pointsToAdd * multiplier;
        scoreText.setScoreText(score);
    }

    public int getMultiplier()
    {
        return multiplier;
    }

    public void startGameplay()
    {
        gameplayHasStarted = true;
        setInitialPositions(getNewPositions());
        resetScoreAndMultiplier();

        

        ///////////////////////////////////////////
        //CODE PORTION TO SEND INFO TO THE TUTORIAL

        if (isFirstTimeNormalGame())
        {
            timerController.pauseTimer();
            GetComponentInChildren<TutorialScript>().startTutorial();
        }

        ///////////////////////////////////////////

    }

    public void restartGame()
    {   
        ///////////////////////////////////////////
        // RESTARTING THE CURRENT SCENE
        //////////////////////////////////////////
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void centerItemClicked()
    {
        soundController.playRoundSound();
        centerItem.deactivate();
        roundCompleted();

        ///////////////////////////////////////////
        //CODE PORTION TO SEND INFO TO THE TUTORIAL

        if (isFirstTimeNormalGame())
        {
            GetComponentInChildren<TutorialScript>().centerItemClicked();
        }

        ///////////////////////////////////////////
    }

    public int getScore()
    {
        return score;
    }

    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public int getHighScore()
    {
        return highscore;
    }

    void resetGameplay()
    {
        deactivateAllItems();
        setInitialPositions(getNewPositions());
    }

    bool isFirstTimeNormalGame()
    {
        int isFirstTime = PlayerPrefs.GetInt("isFirstTime");
        if (isFirstTime !=1 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void addMultiplier()
    {
        multiplier++;
        GetComponentInChildren<MultiplierText>().updateMultiplier(multiplier);
    }
    void resetMultiplier()
    {
        multiplier = 1;
        GetComponentInChildren<MultiplierText>().updateMultiplier(multiplier);
    }
}

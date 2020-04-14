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

    public bool gameplayHasStarted = false;
    int pointsPerCorrect = 100;
    int pointsPerCenter = 500;


    int score;
    int multiplier;

	// Use this for initialization
	void Start () {
        centerItem = this.GetComponentInChildren<CenterItem>();
        clickableObjects = this.GetComponentsInChildren<ClickableItem>();
        timerController = GetComponent<TimerController>();
        gameOverMenu = GetComponentInChildren<GameOverMenu>();
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

    void disableAllItems()
    {
        for (int i = 0; i < clickableObjects.Length; i++)
        {
            clickableObjects[i].Deactivate();
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

        if(position+1 >= clickableObjects.Length)
        {
            centerItem.activate();
        }
        else
        {
            activateNextItem(position);
        }
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
        disableAllItems();
        gameOverMenu.triggerGameOverMenu();
    }

    void roundCompleted()
    {
        addScore(pointsPerCenter);
        multiplier++;
        setInitialPositions(getNewPositions());

        //Restart the action timer each time a round has been completed
        timerController.restartActionTimer();
    }

    void resetScoreAndMultiplier()
    {
        score = 0;
        multiplier = 1;
    }

    void addScore(int pointsToAdd)
    {
        score = score + pointsToAdd * multiplier;
      
    }

    public int getMultiplier()
    {
        return multiplier;
    }

    public void startGameplay()
    {
        Debug.Log("test");
        gameplayHasStarted = true;
        setInitialPositions(getNewPositions());
        resetScoreAndMultiplier();
    }

    public void restartGame()
    {
        /*gameplayHasStarted = false;
        timerController.restartTimers();
        gameOverMenu.hideGameOverMenu();*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void centerItemClicked()
    {
        centerItem.deactivate();
        roundCompleted();
    }

    public int getScore()
    {
        return score;
    }
}

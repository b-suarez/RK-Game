using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    int currentAvailableNumber;
    ClickableItem[] clickableObjects;
    TimerController timerController;
    GameOverMenu gameOverMenu;

    int pointsPerCorrect = 100;


    int score;
    int multiplier;

	// Use this for initialization
	void Start () {
        clickableObjects = this.GetComponentsInChildren<ClickableItem>();
        timerController = GetComponent<TimerController>();
        gameOverMenu = GetComponentInChildren<GameOverMenu>();
        setInitialPositions(getNewPositions());
        resetScoreAndMultiplier();
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

        addScore();

        if(position+1 >= clickableObjects.Length)
        {
            roundCompleted();
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

    void addScore()
    {
        score = score + pointsPerCorrect * multiplier;
        Debug.Log(score);
    }

    public int getMultiplier()
    {
        return multiplier;
    }

    public void restartGame()
    {
        setInitialPositions(getNewPositions());
        resetScoreAndMultiplier();
        timerController.restartTimers();
        gameOverMenu.hideGameOverMenu();
    }
}

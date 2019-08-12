using UnityEngine;

public class HitPointManager : MonoBehaviour {

    HitPointScript[] hitPointsArray;
    GameController gameController;
    CenterButton centerButton;
    GameplaySounds gameplaySounds;

    int nextInSequence;
    public int scoreWhenCorrect;

	// Use this for initialization
	void Awake () {
        hitPointsArray = GetComponentsInChildren<HitPointScript>();
        centerButton = GetComponentInChildren<CenterButton>();
        gameController = GetComponentInParent<GameController>();
        gameplaySounds = GetComponent<GameplaySounds>();
        nextInSequence = 0;
        //ResetPositionsInSequence();
	}

    public void HittedBY(int hittedHP)
    {
        if(hittedHP == nextInSequence)
        {
            if(nextInSequence >= hitPointsArray.Length -1)
            {
                centerButton.Activate();    
            }

            else
            {
                nextInSequence++;

            }
            ///This is good, go to the next one
            ///
            gameplaySounds.PlaySmallButtonSound();
            gameController.AddScore(scoreWhenCorrect);
        }
        else
        {
            ///Error sound and reset number
            gameController.Error();
            ResetPositionsInSequence();
        }
    }

    public void ResetPositionsInSequence()
    {
        nextInSequence = 0;

        //Set every HitPoint as not set
        for (int i = 0; i < hitPointsArray.Length; i++)
        {
            hitPointsArray[i].isSetInSequence = false;
            hitPointsArray[i].canBeClicked = true;
        }

        // Add a random position to the hitpoint 0 and so on

        for (int i = 0; i < hitPointsArray.Length; i++)
        {
            // This script executes until the position [i] finds a proper random number

            do
            {
                bool canBeAdded = true;
                int numberToEnter = GenerateRandom();

                for (int j = 0; j < hitPointsArray.Length; j++)
                {
                    if (hitPointsArray[j].isSetInSequence && hitPointsArray[j].positionInSequence == numberToEnter)
                    {
                        canBeAdded = false;
                    }
                }

                if (canBeAdded)
                {
                    hitPointsArray[i].SetPositionInSequence(numberToEnter);
                    
                }

            } while (hitPointsArray[i].isSetInSequence == false);

        }
    }

    int GenerateRandom()
    {
        return Random.Range(0, hitPointsArray.Length);
    }

    public void BlockButtons()
    {
        for (int i = 0; i < hitPointsArray.Length; i++)
        {
            hitPointsArray[i].canBeClicked = false;
            hitPointsArray[i].Block();
        }
    }


}

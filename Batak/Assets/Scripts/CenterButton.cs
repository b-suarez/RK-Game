using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterButton : MonoBehaviour {
    public bool canBeClicked;
    HitPointManager hitPointManager;
    GameController gameController;

    // Use this for initialization
    void Start () {
        canBeClicked = false;
        GetComponent<Animator>().SetBool("Blocked", true);
        hitPointManager = GetComponentInParent<HitPointManager>();
        gameController = GetComponentInParent<GameController>();

	}
	
    public void Activate()
    {
        canBeClicked = true;
        GetComponent<Animator>().SetBool("Blocked", false);
    }

    public void Clicked()
    {
        if (canBeClicked)
        {
            ///AddScore
            ///
            hitPointManager.ResetPositionsInSequence();
            canBeClicked = false;
            GetComponent<Animator>().SetBool("Blocked", true);
            gameController.CenterButtonClicked();
        }
        
    }

}

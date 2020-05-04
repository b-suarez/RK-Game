using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    Animator menuAnimator;

	// Use this for initialization
	void Start () {
        menuAnimator = GetComponent<Animator>();
	}
	
	public void triggerNormalGameAnimation()
    {
        menuAnimator.SetTrigger("normal-game-trigger");
    }

    public void triggerSurvivalGameAnimation()
    {
        menuAnimator.SetTrigger("survival-game-trigger");
    }
}

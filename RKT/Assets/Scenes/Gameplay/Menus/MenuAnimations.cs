using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour {
    Animator menuAnimator;

	// Use this for initialization
	void Start () {
        menuAnimator = GetComponent<Animator>();
	}
	
    public void playErrorAnim()
    {
        menuAnimator.SetTrigger("error");
    }

    public void playRoundCompletedAnim()
    {
        menuAnimator.SetTrigger("round-completed");
    }

}

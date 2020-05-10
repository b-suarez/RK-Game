using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    Animator menuAnimator;
    SoundTrackController soundTrackController;

	// Use this for initialization
	void Start () {
        menuAnimator = GetComponent<Animator>();
        soundTrackController = GetComponentInChildren<SoundTrackController>();
        soundTrackController.startSoundtrackWithFadeIn();
	}
	
	public void triggerNormalGameAnimation()
    {
        menuAnimator.SetTrigger("normal-game-trigger");
        soundTrackController.triggerFadeOut();
    }

    public void triggerSurvivalGameAnimation()
    {
        menuAnimator.SetTrigger("survival-game-trigger");
        soundTrackController.triggerFadeOut();
    }

    public void triggerLeaderboardAnimation()
    {
        menuAnimator.SetTrigger("leaderboard-trigger");
        soundTrackController.triggerFadeOut();
    }
    public void triggerAboutAnimation()
    {
        menuAnimator.SetTrigger("about-trigger");
        soundTrackController.triggerFadeOut();
    }
}

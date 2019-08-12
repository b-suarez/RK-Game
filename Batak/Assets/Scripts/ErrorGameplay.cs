using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorGameplay : MonoBehaviour {
    Animator animator;
    AudioSource audioError;
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioError = GetComponent<AudioSource>();
    }
    public void SetErrorGameplay()
    {
        animator.SetTrigger("Error");
        audioError.Play();
        Handheld.Vibrate();
    }
    public void SetCorrectButton()
    {
        animator.SetTrigger("CenterButtonTapped");
    }
}

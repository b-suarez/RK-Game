using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointScript : MonoBehaviour {
    public bool canBeClicked;
    public bool isSetInSequence;

    public Animator animator;

    public int positionInSequence;
    HitPointManager hitPointManager;

    private void Start()
    {
        hitPointManager = GetComponentInParent<HitPointManager>();
        canBeClicked = false;
        animator = GetComponent<Animator>();
        Block();
       
    }

    public void SetPositionInSequence(int receivedPosition)
    {
        positionInSequence = receivedPosition;
        canBeClicked = true;
        isSetInSequence = true;
        if (animator != null)
        {
            animator.SetBool("Blocked", false);
        }

    }

    public void Clicked()
    {
        if (canBeClicked)
        {
            canBeClicked = false;
            animator.SetBool("Blocked", true);
            hitPointManager.HittedBY(positionInSequence);
        }
       
    }

    public void Block()
    {
        animator.SetBool("Blocked", true);
    }


    

}

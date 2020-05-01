using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterItem : MonoBehaviour {

    bool active;
    Animator animator;

	// Use this for initialization
	void Start () {
        active = false;
        animator = gameObject.GetComponent<Animator>();
	}

    public void activate()
    {
        animator.SetBool("active", true);
        active = true;

    }

    public void deactivate()
    {
        animator.SetBool("active", false);
        active = false;
    }

    public bool isActive()
    {
        return active;
    }

    public void clicked()
    {
        if (active)
        {
            if (GetComponentInParent<GameController>())
            {
                GetComponentInParent<GameController>().centerItemClicked();
            }
            else if (GetComponentInParent<SurvivalModeController>())
            {
                GetComponentInParent<SurvivalModeController>().centerItemClicked();
            }
            
        }
    }
	
}

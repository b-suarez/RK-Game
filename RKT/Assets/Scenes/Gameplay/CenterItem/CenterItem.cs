using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterItem : MonoBehaviour {

    public bool active;
    Animator animator;

	// Use this for initialization
	void Start () {
        active = false;
        animator = gameObject.GetComponent<Animator>();
	}

    public void activate()
    {
        animator.SetTrigger("activate");
        active = true;

    }

    public void deactivate()
    {
        animator.SetTrigger("deactivate");
        active = false;
    }

    public void clicked()
    {
        if (active)
        {
            GetComponentInParent<GameController>().centerItemClicked();
        }
    }
	
}

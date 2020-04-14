using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItem : MonoBehaviour {

    bool active = false;
    int position;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    public void Clicked()
    {
        if (active)
        {
            this.GetComponentInParent<GameController>().clickedPosition(position);
            
        }
    }

    public void Activate()
    {
        animator.SetTrigger("activate-item");
        active = true;
    }

    public void Deactivate()
    {
        animator.SetTrigger("deactivate-item");
        active = false;
    }

    public void SetPositionText(int receivedPosition)
    {
        position = receivedPosition;
        this.GetComponentInChildren<Text>().text = (position+1).ToString();
    }

    public int GetPosition()
    {
        return position;
    }
}

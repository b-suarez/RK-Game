using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalModeClickableItem : MonoBehaviour
{

    public bool active = false;
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
            GetComponentInParent<SurvivalModeController>().clickedPosition(position);
        }
    }

    public void Activate()
    {

        animator.SetBool("active", true);
        active = true;
    }

    public void Deactivate()
    {
        animator.SetBool("active", false);
        active = false;
    }

    public void SetPositionText(int receivedPosition)
    {
        position = receivedPosition;
        //this.GetComponentInChildren<Text>().text = (position+1).ToString();
    }

    public int GetPosition()
    {
        return position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    Animator animatorController;


    public void triggerGameOverMenu()
    {
        animatorController = gameObject.GetComponent<Animator>();
        animatorController.SetTrigger("trigger-activation");
      
    }

    public void hideGameOverMenu()
    {
        GetComponent<Transform>().localPosition = new Vector3(-300, 0, 0);
    }
}

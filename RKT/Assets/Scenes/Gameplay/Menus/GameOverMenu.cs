using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    public void triggerGameOverMenu()
    {
        GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }

    public void hideGameOverMenu()
    {
        GetComponent<Transform>().localPosition = new Vector3(-300, 0, 0);
    }
}

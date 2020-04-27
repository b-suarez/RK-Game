using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = GetComponentInParent<GameOverMenu>().highScoreToDisplay.ToString() ;
	}
}

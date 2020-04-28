using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {
	
	public void setHighScore(int highScore)
	{
		GetComponent<Text>().text = highScore.ToString();
	}
}

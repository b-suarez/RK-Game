using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLabel : MonoBehaviour {

    public GameObject HSGO;
    public GameObject PSGO;

    public void SetScores(int highScore, int playerScore)
    {
        HSGO.GetComponent<Text>().text = highScore.ToString();
        PSGO.GetComponent<Text>().text = playerScore.ToString();
    }
}

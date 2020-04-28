using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    Text textField;
    // Use this for initialization
    void Start()
    {
        textField = GetComponent<Text>();
    }

    public void setScoreText(int score)
    {
        textField.text = score.ToString();
    }
}

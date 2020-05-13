using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
    }

    public void updateText(string score)
    {
        text.text = score;
    }
}

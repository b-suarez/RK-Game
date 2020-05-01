using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalModeTotalTimerText : MonoBehaviour
{
    Text totalTimerText;
    // Start is called before the first frame update
    void Start()
    {
        totalTimerText = GetComponent<Text>();
    }

    public void updateTotalTimerText(float time)
    {
        totalTimerText.text = time.ToString("F1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalModeFinalScore : MonoBehaviour
{
    Text totalTimeText;
    // Start is called before the first frame update
    void Start()
    {
        totalTimeText = GetComponent<Text>();
    }

    public void setTotalTimeText(float totalTime)
    {
        totalTimeText.text = totalTime.ToString("F0") + "'";
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalModeBestTimeText : MonoBehaviour
{
    Text bestTimeText;
    // Start is called before the first frame update
    void Start()
    {
        bestTimeText = GetComponent<Text>();
    }

   public void setBestTimeText(float bestTime)
    {
        bestTimeText.text = bestTime.ToString("F0")+"'";
    }
}

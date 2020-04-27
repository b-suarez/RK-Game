using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepScript : MonoBehaviour
{

    public int order;
    public bool isActive;
    public string text;
    public bool deactivatesInTime;
    public float time;
    float timeLeft;

    private void Start()
    {
        GetComponentInChildren<Text>().text = text;
        
    }

    private void Update()
    {

    }


    public void activate()
    {
        isActive = true;
        GetComponent<Animator>().SetBool("active", true);
    }

    public void deactivate()
    {
        isActive = false;
        GetComponent<Animator>().SetBool("active", false);
    }

}
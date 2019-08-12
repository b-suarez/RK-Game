using UnityEngine;
using UnityEngine.UI;

public class MinuteTimer : MonoBehaviour {
    public float _timeLeft;

    Text _minuteTextUI;
    bool hasStarted;
    GameController gameController;

	// Use this for initialization
	void Awake () {
        hasStarted = false;
        _timeLeft = 30.0f;
        _minuteTextUI = GetComponent<Text>();
        _minuteTextUI.text = _timeLeft.ToString("0.00");

        gameController = GetComponentInParent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (hasStarted)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                _minuteTextUI.text = _timeLeft.ToString("0.00");

            }
            else
            {
                _timeLeft = 0.00f;
                _minuteTextUI.text = _timeLeft.ToString("0.00");
                gameController.TimeOver();

            }
        }    
    }
    public void StartTimer()
    {
        hasStarted = true;
    }

    public void AddSeconds(int secondsAdded)
    {
        _timeLeft = _timeLeft + secondsAdded;
    }

    public void SubtractSeconds(int secondsSubstracted)
    {
        _timeLeft = _timeLeft - secondsSubstracted;
    }

}

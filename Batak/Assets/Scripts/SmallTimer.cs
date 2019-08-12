using UnityEngine;
using UnityEngine.UI;

public class SmallTimer : MonoBehaviour {
    public float TimeToReset;

    float _timeLeft;
    Text _smallTimerTextUI;

    // Use this for initialization
    void Start()
    {
        _timeLeft = TimeToReset;
        _smallTimerTextUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeLeft > 0.02f)
        {
            _timeLeft -= Time.deltaTime;

        }
        else
        {
            ResetTimer();
        }

        _smallTimerTextUI.text = _timeLeft.ToString("0.00");

    }

    public void ResetTimer()
    {
        _timeLeft = TimeToReset;
    }
}

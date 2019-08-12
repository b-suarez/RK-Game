using UnityEngine;
using UnityEngine.UI;

public class MultiplierText : MonoBehaviour {
    Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.text = "x" + "1";
    }
	
	public void ChangeMultiplier(string _multiplier)
    {
        text.text = "x" + _multiplier;
    }
}

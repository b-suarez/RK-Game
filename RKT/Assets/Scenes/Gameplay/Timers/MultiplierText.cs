using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierText : MonoBehaviour {

	Text multiplierText;

	private void Start()
	{
		multiplierText = GetComponent<Text>();
	}

	public void updateMultiplier(int multiplier)
	{
		multiplierText.text = "x" + multiplier.ToString();
	}
}

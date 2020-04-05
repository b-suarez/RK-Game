using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierText : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "+" +  GetComponentInParent<GameController>().getMultiplier().ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HitBoxText : MonoBehaviour {
    Text text;
    HitPointScript hitPointScript;
    int newNumberToShow;
    // Use this for initialization
    void Start () {
        
        text = GetComponent<Text>();
        hitPointScript = GetComponentInParent<HitPointScript>();
    }
    private void Update()
    {
        newNumberToShow = hitPointScript.positionInSequence + 1;
        text.text = newNumberToShow.ToString();
    }
   

}

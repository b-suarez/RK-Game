using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItem : MonoBehaviour {

    bool canBeClicked = false;
    int position;

    public void Clicked()
    {
        if (canBeClicked)
        {
            this.GetComponentInParent<GameController>().clickedPosition(position);
        }
    }

    public void Activate()
    {
        canBeClicked = true;
    }

    public void Deactivate()
    {
        canBeClicked = false;
    }

    public void SetPositionText(int receivedPosition)
    {
        position = receivedPosition;
        this.GetComponentInChildren<Text>().text = (position+1).ToString();
    }

    public int GetPosition()
    {
        return position;
    }
}

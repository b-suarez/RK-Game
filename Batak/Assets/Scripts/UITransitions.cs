using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransitions : MonoBehaviour {

    public void PlayUITransition()
    {
        GetComponent<Animator>().SetTrigger("TransitionActivated");
    }
    public void PlayFinishAnimation()
    {
        GetComponent<Animator>().SetBool("HasFinished",true);
    }
}

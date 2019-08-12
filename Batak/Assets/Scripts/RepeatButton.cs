using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatButton : MonoBehaviour {

    public void RestartScene()
    {
        if (!GetComponentInParent<GameController>().IsSurvival)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("Survival");
        }
        
    }

}

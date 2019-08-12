using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonEnd : MonoBehaviour {

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

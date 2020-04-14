using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public bool isIntro;

    private void Start()
    {
        if (isIntro)
        {
            loadSceneWithDelayFunc("MainMenu", 2);
        }
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void loadSceneWithDelayFunc(string scene, int delaySeconds)
    {
        StartCoroutine(loadSceneWithDelay(scene, delaySeconds));
    }

    public IEnumerator loadSceneWithDelay(string scene, int delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds - 0.4f);
        gameObject.GetComponent<Animator>().SetTrigger("trigger-fade");
        yield return new WaitForSeconds(0.4f);
        loadScene(scene);
    }

    public void loadSceneWithDelayFadeOut(string scene, int delaySeconds)
    {
        StartCoroutine(loadSceneWithDelay(scene, delaySeconds));
    }

}

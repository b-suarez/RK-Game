using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audio1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playAudio(int position)
    {
        switch (position)
        {
            case 0:
                audioSource.clip = audio1;
                audioSource.Play();
                break;
            default:
                audioSource.clip = audio1;
                audioSource.Play();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            playAudio(0);
        }

    }
}

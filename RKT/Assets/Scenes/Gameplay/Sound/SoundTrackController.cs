using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackController : MonoBehaviour
{
    AudioSource audioSource;
    bool isFadeOut;
    bool isFadeIn;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (isFadeOut)
        {
            if(audioSource.volume >= 0.5f)
            {
                audioSource.volume -= 0.005f;
            }
        }
        if (isFadeIn)
        {
            if (audioSource.volume <= 1)
            {
                audioSource.volume += 0.005f;
            }
            else
            {
                isFadeIn = false;
            }
        }
    }

    public void startSoundtrack()
    {
        audioSource.Play();
    }
    public void startSoundtrackWithFadeIn()
    {
        audioSource.volume = 0.1f;
        audioSource.Play();
        isFadeIn = true;
    }
    public void stopSoundtrack()
    {
        audioSource.Stop();
    }

    public void pauseSoundtrack()
    {
        audioSource.Pause();
    }

    public void triggerFadeOut()
    {
        isFadeOut = true;
    }

    public void triggerFadeIn()
    {
        isFadeIn = true;
    }
}

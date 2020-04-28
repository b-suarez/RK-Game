using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackController : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void startSoundtrack()
    {
        audioSource.Play();
      
    }
    public void stopSoundtrack()
    {
        audioSource.Stop();
    }

    public void pauseSoundtrack()
    {
        audioSource.Pause();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySounds : MonoBehaviour {
    AudioSource audioSource;

    public AudioClip smallButtonSound;
    public AudioClip bigButtonSound;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}

	public void PlaySmallButtonSound()
    {
        audioSource.clip = smallButtonSound;
        
        audioSource.Play();
    }

    public void PlayBigButtonSound()
    {
        audioSource.clip = bigButtonSound;

        audioSource.Play();
    }


}

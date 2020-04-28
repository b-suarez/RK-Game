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
        /////////////////////////////
        ///GIVEN AN ARRAY POSITION IT PLAYS THE SOUND ASSIGNED
        ///TO THAT POSITION X
        //////////////////////////////
        
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
}

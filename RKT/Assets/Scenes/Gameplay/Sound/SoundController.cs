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
                audioSource.pitch = 0.6f;
                audioSource.Play();
                break;

            case 1:
                audioSource.clip = audio1;
                audioSource.pitch = 0.8f;
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = audio1;
                audioSource.pitch = 1f;
                audioSource.Play();
                break;
            case 3:
                audioSource.clip = audio1;
                audioSource.pitch = 1.2f;
                audioSource.Play();
                break;
            case 4:
                audioSource.clip = audio1;
                audioSource.pitch = 1.4f;
                audioSource.Play();
                break;
            case 5:
                audioSource.clip = audio1;
                audioSource.pitch = 1.6f;
                audioSource.Play();
                break;

            default:
                audioSource.clip = audio1;
                audioSource.pitch = Random.Range(0.6f, 1.4f);
                audioSource.Play();
                break;
        }
    }
    public void playActionSuccessSound()
    {
        audioSource.clip = audio1;
        audioSource.pitch = Random.Range(0.6f, 1.4f);
        audioSource.Play();
    }

    public void playRoundSound()
    {
        audioSource.clip = audio1;
        audioSource.pitch = 2f;
        audioSource.Play();
    }
}

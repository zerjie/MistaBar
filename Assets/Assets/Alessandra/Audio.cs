using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    [Header("Shake Audio")]
    public AudioClip[] shakeSounds;
    public AudioSource shake;

    
    [Header("Muddle Audio")]
    public AudioClip[] muddleSounds;
    public AudioSource muddle;
    

    // For project 3, accomodate to all microgames

    void Start()
    {
        shake = GetComponent<AudioSource>();
        muddle = GetComponent<AudioSource>();
    }

    public void PlayRandomShake()
    {
        shake.clip = shakeSounds[Random.Range(0, shakeSounds.Length)];
        shake.PlayOneShot(shake.clip);

        Debug.Log("Shake audio is playing");
    }

    
    public void PlayRandomMuddle()
    {
        // Only have 1 audio at the moment, add more in the future

        muddle.clip = muddleSounds[Random.Range(0, muddleSounds.Length)];
        muddle.PlayOneShot(muddle.clip);

        Debug.Log("Muddle audio is playing");
    }
    

}



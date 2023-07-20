using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    [Header("Shake Audio")]
    public AudioClip[] shakeSounds;
    public AudioSource shake;

    [Header("Muddler Audio")]
    public AudioClip[] muddleSounds;
    public AudioSource muddle;

    void Start()
    {
        shake = GetComponent<AudioSource>();
    }

    public void PlayRandomShake()
    {
        shake.clip = shakeSounds[Random.Range(0, shakeSounds.Length)];
        shake.PlayOneShot(shake.clip);

        Debug.Log("Shake audio is playing");
    }

    public void PlayRandomMuddle()
    {
        muddle.clip = muddleSounds[Random.Range(0, muddleSounds.Length)];
        muddle.PlayOneShot(muddle.clip);

        Debug.Log("Muddle audio is playing");
    }
}



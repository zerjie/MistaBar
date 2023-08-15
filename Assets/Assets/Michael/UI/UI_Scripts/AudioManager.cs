using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip clickSound;
    public AudioClip[] muddleSounds;
    public AudioClip[] shakeSounds;
    public AudioClip sirens;
    public AudioSource bgmSource;
    public AudioSource audioSource;

    void Start()
    {
        if (AudioEvents.currentAudio != null)
        {
            AudioEvents.currentAudio.OnBGM += OnBGM;
            AudioEvents.currentAudio.OnWinSound += OnWinSound;
            AudioEvents.currentAudio.OnLoseSound += OnLoseSound;
            AudioEvents.currentAudio.OnClickSound += OnClickSound;
            AudioEvents.currentAudio.OnMuddleSound += OnMuddleSound;
            AudioEvents.currentAudio.OnShakeSound += OnShakeSound;
            AudioEvents.currentAudio.OnPlaySirens += OnPlaySirens;
        }
        else
        {
            Debug.LogError("AudioEvents.currentAudio is null. Make sure you have an instance of AudioEvents in your scene.");
        }

        if (bgmSource == null)
        {
            Debug.LogError("bgmSource is not assigned. Please assign an AudioSource component in the Inspector.");
        }

        if (audioSource == null)
        {
            Debug.LogError("audioSource is not assigned. Please assign an AudioSource component in the Inspector.");
        }
    }

    private void OnBGM()
    {
            bgmSource.Play();
    }

    private void OnWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    private void OnLoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }

    private void OnClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    private void OnMuddleSound()
    {
        audioSource.clip = muddleSounds[Random.Range(0, muddleSounds.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void OnShakeSound()
    {
        audioSource.clip = shakeSounds[Random.Range(0, shakeSounds.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void OnPlaySirens()
    {
        audioSource.PlayOneShot(sirens);
    }
}

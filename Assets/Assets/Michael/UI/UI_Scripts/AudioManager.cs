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
    public AudioClip crowd;
    public AudioClip[] muddleSounds;
    public AudioClip[] shakeSounds;
    public AudioClip[] plungerSounds;
    public AudioClip sirens;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    void Start()
    {
        if (AudioEvents.currentAudio != null)
        {
            AudioEvents.currentAudio.OnBGM += OnBGM;
            AudioEvents.currentAudio.OnCrowd += OnCrowd;
            AudioEvents.currentAudio.OnWinSound += OnWinSound;
            AudioEvents.currentAudio.OnLoseSound += OnLoseSound;
            AudioEvents.currentAudio.OnClickSound += OnClickSound;
            AudioEvents.currentAudio.OnMuddleSound += OnMuddleSound;
            AudioEvents.currentAudio.OnShakeSound += OnShakeSound;
            AudioEvents.currentAudio.OnPlungeSound += OnPlungeSound;
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

        if (sfxSource == null)
        {
            Debug.LogError("audioSource is not assigned. Please assign an AudioSource component in the Inspector.");
        }
    }

    private void OnBGM()
    {
            bgmSource.Play();
    }

    private void OnCrowd()
    {
        bgmSource.clip = crowd;
        bgmSource.Play();
    }


    private void OnWinSound()
    {
        sfxSource.PlayOneShot(winSound);
    }

    private void OnLoseSound()
    {
        sfxSource.PlayOneShot(loseSound);
    }

    private void OnClickSound()
    {
        sfxSource.PlayOneShot(clickSound);
    }

    private void OnMuddleSound()
    {
        sfxSource.clip = muddleSounds[Random.Range(0, muddleSounds.Length)];
        sfxSource.PlayOneShot(sfxSource.clip);
    }

    public void OnShakeSound()
    {
        sfxSource.clip = shakeSounds[Random.Range(0, shakeSounds.Length)];
        sfxSource.PlayOneShot(sfxSource.clip);
    }
    private void OnPlungeSound()
    {
        sfxSource.clip = plungerSounds[Random.Range(0, plungerSounds.Length)];
        sfxSource.PlayOneShot(sfxSource.clip);
    }

    private void OnPlaySirens()
    {
        sfxSource.PlayOneShot(sirens);
    }
}

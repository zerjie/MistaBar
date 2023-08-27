using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    public static AudioEvents currentAudio;
    private void Awake()
    {
        if (currentAudio == null)
        {
            currentAudio = this;
        }

    }

    public event Action OnBGM;
    public void BGMStart()
    {
        if (OnBGM != null)
        {
            OnBGM();
        }
    }

    public event Action OnCrowd;
    public void CrowdStart()
    {
        if (OnCrowd != null)
        {
            OnCrowd();
        }
    }

    public event Action OnWinSound;
    public void WinSound()
    {
        if (OnWinSound != null)
        {
            OnWinSound();
        }
    }

    public event Action OnLoseSound;
    public void LoseSound()
    {
        if (OnLoseSound != null)
        {
            OnLoseSound();
        }
    }

    public event Action OnClickSound;
    public void ClickSound()
    {
        if (OnClickSound != null)
        {
            OnClickSound();
        }
    }

    public event Action OnMuddleSound;
    public void MuddleSound()
    {
        if (OnMuddleSound != null)
        {
            OnMuddleSound();
        }
    }

    public event Action OnShakeSound;
    public void ShakeSound()
    {
        if (OnShakeSound != null)
        {
            OnShakeSound();
        }
    }

    public event Action OnPlungeSound;
    public void PlungeSound()
    {
        if (OnPlungeSound != null)
        {
            OnPlungeSound();
        }
    }

    public event Action OnPlaySirens;
    public void PlaySirens()
    {
        if (OnPlaySirens != null)
        {
            OnPlaySirens();
        }
    }
}

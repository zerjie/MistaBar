using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        if (bgm != null && bgm.clip != null)
        {
            // Play the audio clip in a loop
            bgm.Play();
        }
    }
}

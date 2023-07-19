using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    [Header("Shake Audio")]
    public AudioSource shake;
    public AudioClip shakeClip;

    [Header("Muddler Audio")]
    public AudioSource muddle;
    public AudioClip muddleClip;

    // Update is called once per frame
    void Update()
    {
        /* if method is invoked in shaking script
         *      shake.PlayOneShot(shakeClip);
         */

        /* if method is invoked in muddling script
         *      muddle.PlayOneShot(muddleClip);
         */
    }
}

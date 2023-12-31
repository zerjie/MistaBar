using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garnish : MonoBehaviour
{
    public GameObject garnish;
    public Sprite[] newSprites;
    private bool beenClicked = false;
    private SpriteRenderer spriteRenderer;
    public AudioClip correctSound;
    private AudioSource audioSource;
    private void Awake()
    {
        spriteRenderer = garnish.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            spriteRenderer.sprite = newSprites[Random.Range(0, 3)];
            audioSource.PlayOneShot(correctSound);
        }
        beenClicked = true;
    }
}

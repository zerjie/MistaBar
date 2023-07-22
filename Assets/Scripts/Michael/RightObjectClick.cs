using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightObjectClick : MonoBehaviour
{
    private PickIngredientController controller;
    private bool beenClicked = false;
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public AudioClip correctSound;
    private AudioSource audioSource;

    public void Start()
    {
        ///finds object in scene
        controller = FindObjectOfType<PickIngredientController>();
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    //calls function when player clicks
    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            controller.RightObjectClicked();
            spriteRenderer.sprite = newSprite;
            audioSource.PlayOneShot(correctSound);


        }
        beenClicked = true; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightObjectClick : MonoBehaviour
{
    private PickIngredientController controller;
    private bool beenClicked = false;
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public void Start()
    {
        ///finds object in scene
        controller = FindObjectOfType<PickIngredientController>();
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
    }

    //calls function when player clicks
    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            controller.RightObjectClicked();
            spriteRenderer.sprite = newSprite;
            AudioEvents.currentAudio.WinSound();


        }
        beenClicked = true; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public Sprite newSprite;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        // Check if the mouse click occurred on this game object
        if (Input.GetMouseButtonDown(0))
        {
            // Change the sprite to the new sprite
            spriteRenderer.sprite = newSprite;
        }
    }
}
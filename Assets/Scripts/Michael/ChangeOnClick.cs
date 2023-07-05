using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public GameObject garnish;
    public Sprite[] newSprites;

    private SpriteRenderer spriteRenderer;




    private void Awake()
    {
        spriteRenderer = garnish.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        // Check if the mouse click occurred on this game object
        if (Input.GetMouseButtonDown(0))
        {
            // Change the sprite to the new sprite
            spriteRenderer.sprite = newSprites[Random.Range(0,3)];
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garnish : MonoBehaviour
{
    public GameObject garnish;
    public Sprite[] newSprites;
    private bool beenClicked = false;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = garnish.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            spriteRenderer.sprite = newSprites[Random.Range(0, 3)];
        }
        beenClicked = true;
    }
}

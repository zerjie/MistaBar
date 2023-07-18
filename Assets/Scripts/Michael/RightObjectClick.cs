using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightObjectClick : MonoBehaviour
{
    private PickIngredientController controller;
    private bool beenClicked = false;
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        ///finds object in scene
        controller = FindObjectOfType<PickIngredientController>();
    }

    //calls function when player clicks
    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            controller.RightObjectClicked();
            spriteRenderer.sprite = newSprite;
        }
        beenClicked = true;
        Debug.Log("Obj clicked");
    }
}

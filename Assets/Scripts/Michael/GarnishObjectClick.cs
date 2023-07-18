using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarnishObjectClick : MonoBehaviour
{
    private GarnishController controller;
    private bool beenClicked = false;

    public void Start()
    {
        ///finds object in scene
        controller = FindObjectOfType<GarnishController>();
    }

    //calls function when player clicks
    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            controller.RightObjectClicked();
        }
        beenClicked= true;
        Debug.Log("Obj clicked");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightObjectClick : MonoBehaviour
{
    private GarnishController controller;
    private bool beenClicked = false;

    public void Start()
    {
        controller = FindObjectOfType<GarnishController>();
    }

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

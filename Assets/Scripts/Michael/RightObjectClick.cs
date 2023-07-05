using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightObjectClick : MonoBehaviour
{
    private RightObjectController controller;


    public void Start()
    {
        controller = FindObjectOfType<RightObjectController>();
    }

    private void OnMouseDown()
    {
        controller.RightObjectClicked();
        Debug.Log("Obj clicked");
    }
}

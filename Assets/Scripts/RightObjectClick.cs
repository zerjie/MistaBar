using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightObjectClick : MonoBehaviour
{
    private PickIngredientsController controller;


    public void Start()
    {
        controller = FindObjectOfType<PickIngredientsController>();
    }

    private void OnMouseDown()
    {
        controller.RightObjectClicked();
        Debug.Log("Obj clicked");
    }
}

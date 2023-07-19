using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrunkClick : MonoBehaviour
{
    private PickDrunkController controller;
    private bool beenClicked = false;

    public void Start()
    {
        ///finds object in scene
        controller = FindObjectOfType<PickDrunkController>();
    }

    //calls function when player clicks
    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            controller.RightObjectClicked();
        }
        beenClicked= true;
    }
}

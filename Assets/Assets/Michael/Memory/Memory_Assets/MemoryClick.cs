using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryClick : MonoBehaviour
{
    private MemoryManager manager;
    private bool beenClicked = false;

    public void Start()
    {
        ///finds object in scene
        manager = FindObjectOfType<MemoryManager>();
    }

    //calls function when player clicks
    private void OnMouseDown()
    {
        if (!beenClicked)
        {
            manager.RightObjectClicked();
        }
        beenClicked = true;
    }
}

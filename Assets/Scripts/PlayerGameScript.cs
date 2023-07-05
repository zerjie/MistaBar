using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Player
{
    public class PlayerGameScript : MonoBehaviour
    {
        public void Start()
        {
            InputManager.instance.OnJump += Jump;
            InputManager.instance.OnRight += MoveRight;
            InputManager.instance.OnLeft += MoveLeft;
            InputManager.instance.OnDown += MoveDown;
            InputManager.instance.OnUp += MoveUp;
            EventManager.instance.UpdateUI("9/10HP");
        }

        protected virtual void Jump()
        {
            Debug.Log("Jump!");
        }

        protected virtual void MoveRight()
        {
            Debug.Log("Move Right!");
        }

        protected virtual void MoveLeft()
        {
            Debug.Log("Move Left!");
        }

        protected virtual void MoveUp()
        {
            Debug.Log("Move Up!");
        }

        protected virtual void MoveDown()
        {
            Debug.Log("Move Down!");
        }
    }
}
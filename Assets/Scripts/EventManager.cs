using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Example;
using Example.Player;

namespace Example
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager instance;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public event Action<string> OnUpdateUI; //Output, attach an String to the action
        public void UpdateUI(string text) //Input, passing a string to anything listening
        {
            OnUpdateUI?.Invoke(text);
        }
    }
}


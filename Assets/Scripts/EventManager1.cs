using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Example;

namespace Example
{
    public class EventManager1 : MonoBehaviour
    {
        public static EventManager1 instance;

        public void Awake()
        {

            //PlayerGameScript ps;
        }

        public event Action<string> OnUpdateUI; //Output, attach an String to the action
        public void UpdateUI(string text) //Input, passing a string to anything listening
        {
            OnUpdateUI?.Invoke(text);
        }
    }
}


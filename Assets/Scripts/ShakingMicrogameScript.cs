using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShakingMicrogameScript : MonoBehaviour
{
    // Change depending on UI Manager
    public GameObject instruction;
    public int counter;
    
    // Fixed 
    public float mashDelay = 0.5f;
    public GameObject shaker;
    public GameObject timerbar;
    
    //[SerializeField] Text counterUI;

    private float mash; 
    bool pressed;
    float shakesToWin = 30;

    bool callOnce;

    // Start is called before the first frame update
    void Start()
    {

        mash = mashDelay;

        //Countdown();

        // Change later depending on UI
        instruction.SetActive(true);
    }

    void Update()
    {
        GameStart();
    }

    public void GameStart()
    {
        if (!callOnce)
        {
            mash -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && !pressed)
            {
                pressed = true;
                mash = mashDelay;
            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                pressed = false;
                counter++;

                // Change later depending on UI
                instruction.SetActive(false);

                if (counter % 2 == 0)
                {
                    shaker.transform.position = new Vector3(-1.32f, -0.8f, 0.0f);
                }

                else
                {
                    shaker.transform.position = new Vector3(1.5f, 1.3f, 1.0f);
                }
            }

            if (counter == shakesToWin)
            {
                WinCondition();
            }

                callOnce = true;
            }
        }
    public void WinCondition()
    {
        instruction.GetComponent<Text>().text = "Win";
        instruction.SetActive(true);
        shaker.SetActive(false);
        Debug.Log("Player Succeeded");
        instruction.transform.position = new Vector3(0f, 0f, 0f);
        // Insert positive game end here to return to UI and Game Manager
        return;
    }

    public void LoseCondition()
    {
        instruction.GetComponent<Text>().text = "FAILED";
        instruction.SetActive(true);
        shaker.SetActive(false);
        Debug.Log("Player Failed");
        instruction.transform.position = new Vector3(0f, 0f, 0f);
        // Insert negative game end here to return to UI and Game Manager
        return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toilet : MonoBehaviour
{
    // Change depending on UI Manager
    [Header("UI")]
    public GameObject instruction;
    public Text counterText;
    public int counter;

    [Header("Toilet")]
    public float mashDelay = 0.5f;
    public GameObject plunger;

    [Header("Frogs")]
    public GameObject[] Frogs;

    [Header("Sound")]
    public Audio audioManager;

    private float mash;
    bool pressed;
    float plungesToWin = 60;

    // Start is called before the first frame update
    void Start()
    {
        mash = mashDelay;

        // Change later depending on UI
        instruction.SetActive(true);
    }

    void Update()
    {
        counterText.text = counter.ToString() + "/60";
        GameStart();
    }

    public void GameStart()
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

            Debug.Log("Key pressed");

            // Change later depending on UI
            instruction.SetActive(false);

            if (counter % 2 == 0)
            {
                plungeDown();
                plungeSound();
            }

            else
            {
                plungeUp();
            }
        }

        if (counter >= plungesToWin)
        {
            FrogsEscape();
            WinCondition();
        }
    }
    public void WinCondition()
    {
        GameEvents.current.PlayerWin();
        GameEvents.current.CloseGame();
    }

    public void LoseCondition()
    {
        GameEvents.current.PlayerLose();
        GameEvents.current.CloseGame();
    }

    public void plungeDown()
    {
        plunger.transform.position = new Vector3(-0.15f, -1.70f, 1.0f);
    }

    public void plungeUp()
    {
        plunger.transform.position = new Vector3(-0.13f, 2.93f, 1.0f);
    }

    void FrogsEscape()
    {
        //
    }

    private void plungeSound()
    {
        Debug.Log("Other function is called");
        //audioManager.PlayRandomPlunge();
    }
}
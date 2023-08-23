using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ToiletGame : MonoBehaviour
{
    [Header("UI")]
    public Text counterText;
    public int counter;

    [Header("Toilet")]
    public GameObject plunger;

    [Header("Sound")]
    public Audio audioManager;

    private float mashDelay = 0.5f;
    private float mash;
    
    public bool frogsEscape;

    bool pressed;
    float plungesToWin = 40;


    public void GameStart()
    {
        counterText.text = counter.ToString() + "/40";

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
            WinCondition();
        }
    }
    public void WinCondition()
    {
        frogsEscape = true;
        Debug.Log("Frog called");

        //GameEvents.current.PlayerWin();
        //GameEvents.current.CloseGame();
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

    private void plungeSound()
    {
        Debug.Log("Other function is called");
        //audioManager.PlayRandomPlunge();
    }
}

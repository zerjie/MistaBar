using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickIngredientsController : MonoBehaviour
{
    float allowedTime = 5.0f;
    float timeRemaining;
    [SerializeField] Image timerBar;
   // [SerializeField] GameObject[] spawnpoints;
    //[SerializeField] GameObject[] clickableObjects;
    public int pointCount;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = allowedTime;

       // Instantiate(clickableObjects[Random.Range(1,5)], spawnpoints[1].transform);
    }

    // Update is called once per frame
    void Update()
    {

        FillTimer();
        if (timeRemaining <= 0)
        {
            Debug.Log(" Ran out of Time!");
        }

        if (pointCount == 3)
        {
            Debug.Log("You win!");
        }
    }


    void FillTimer()
    {
        timeRemaining -= Time.deltaTime;
        float timerFill = timeRemaining / allowedTime;
        timerBar.fillAmount = timerFill;
    }

}

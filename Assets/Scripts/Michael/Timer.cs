using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float allowedTime = 5.0f;
    float timeRemaining;
    bool gameStarted;
    [SerializeField] Image timerBar;
    public Image managerSprite;
    public Sprite angrySprite;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = allowedTime;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
        }
        
        if (gameStarted)
        {
            FillTimer();
        }

        if (timeRemaining < 2.5)
        {
            managerSprite = manager.GetComponent<Image>();
            managerSprite.sprite = angrySprite;
        }

        if (timeRemaining <= 0)
        {
            Debug.Log(" Ran out of Time!");
            gameStarted = false;
        }
    }

    void FillTimer()
    {
        timeRemaining -= Time.deltaTime;
        float timerFill = timeRemaining / allowedTime;
        timerBar.fillAmount = timerFill;
    }
}
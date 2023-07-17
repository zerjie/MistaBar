using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float allowedTime = 5.0f;
    public float timeRemaining;
    [SerializeField] Image timerBar;
    public Image managerSprite;
    public Sprite happySprite;
    public Sprite angrySprite;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = allowedTime;
        managerSprite = manager.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        FillTimer();

        if (timeRemaining < 2.5)
        {
            
            managerSprite.sprite = angrySprite;
        }

        if (timeRemaining <= 0)
        {
            GameEvents.current.TimeOut();
            GameEvents.current.CloseGame();
        }
    }

    void FillTimer()
    {
        timeRemaining -= Time.deltaTime;
        float timerFill = timeRemaining / allowedTime;
        timerBar.fillAmount = timerFill;
    }

    public void HappyManager()
    {
        managerSprite.sprite = angrySprite;
    }
}
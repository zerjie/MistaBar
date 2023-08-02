using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float allowedTime = 8.0f;
    public float timeRemaining;
    public Image managerSprite;
    public Sprite happySprite;
    public Sprite angrySprite;
    public MicroGameManager microGameManager;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject instruction3;
    public GameObject instruction4;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = allowedTime;
        managerSprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        FillTimer();
        if (timeRemaining < 6)
        {
            instruction1.SetActive(false);
            instruction2.SetActive(false);
            instruction3.SetActive(false);
            instruction4.SetActive(false);

        }
        if (timeRemaining < 4)
        {
            
            managerSprite.sprite = angrySprite;
        }

        if (timeRemaining <= 0 && microGameManager.selectedMicroGame !=7)
        {
            GameEvents.current.TimeOut();
            GameEvents.current.CloseGame();
        }

        if (timeRemaining <= 0 && microGameManager.selectedMicroGame == 7)
        {
            GameEvents.current.PlayerWin();
            GameEvents.current.CloseGame();
        }
    }

    void FillTimer()
    {
        timeRemaining -= Time.deltaTime;
        float timerFill = timeRemaining / allowedTime;
        managerSprite.fillAmount = timerFill;
    }

    public void HappyManager()
    {
        managerSprite.sprite = happySprite;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int playerLives = 4;
    [SerializeField] GameObject life1;
    [SerializeField] GameObject life2;
    [SerializeField] GameObject life3;
    [SerializeField] GameObject life4;

    private void Start()
    {
        playerLives = 4;
    }

    private void Update()
    {
        if (playerLives == 3)
        {
            life4.SetActive(false);
        }
        if (playerLives == 2)
        {
            life3.SetActive(false);
        }
        if (playerLives == 1)
        {
            life2.SetActive(false);
        }
        if (playerLives == 0)
        {
            life1.SetActive(false);
            GameEvents.current.CloseGame();
            GameEvents.current.GameOver();
        }
    }

    public void LoseLife()
    {
        playerLives--;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        if (current == null) 
        {
            current = this;
        }

    }

    public event Action OnPlayerWin;
    public void PlayerWin()
    {
        if (OnPlayerWin != null)
        {
            OnPlayerWin();
        }
    }

    public event Action OnPlayerLose;
    public void PlayerLose()
    {
        if (OnPlayerLose != null)
        {
            OnPlayerLose();
        }
    }

    public event Action OnTimeOut;
    public void TimeOut()
    {
        if (OnTimeOut != null)
        {
            OnTimeOut();
        }
    }

    public event Action OnOpenGame;
    public void OpenGame()
    {
        if (OnOpenGame != null)
        {
            OnOpenGame();
        }
    }

    public event Action OnOpenLastGame;
    public void OpenLastGame()
    {
        if (OnOpenLastGame != null)
        {
            OnOpenLastGame();
        }
    }

    public event Action OnCloseGame;
    public void CloseGame()
    {
        if (OnCloseGame != null)
        {
            OnCloseGame();
        }
    }

    public event Action OnTransition;
    public void Transition()
    {
        if (OnTransition != null)
        {
            OnTransition();
        }
    }

    public event Action OnGameOver;
    public void GameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public event Action OnFinishGame;
    public void FinishGame()
    {
        if (OnFinishGame != null)
        {
            OnFinishGame();
        }
    }

    public event Action OnPlaySirens;
    public void PlaySirens()
    {
        if (OnPlaySirens != null)
        {
            OnPlaySirens();
        }
    }

}

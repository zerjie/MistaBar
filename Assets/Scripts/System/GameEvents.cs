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

    public event Action onPlayerWin;
    public void PlayerWin()
    {
        if (onPlayerWin != null)
        {
            onPlayerWin();
        }
    }

    public event Action onPlayerLose;
    public void PlayerLose()
    {
        if (onPlayerLose != null)
        {
            onPlayerLose();
        }
    }

    public event Action onTimeOut;
    public void TimeOut()
    {
        if (onTimeOut != null)
        {
            onTimeOut();
        }
    }

    public event Action onOpenGame;
    public void OpenGame()
    {
        if (onOpenGame != null)
        {
            onOpenGame();
        }
    }

    public event Action onCloseGame;
    public void CloseGame()
    {
        if (onCloseGame != null)
        {
            onCloseGame();
        }
    }

    public event Action onTransition;
    public void Transition()
    {
        if (onTransition != null)
        {
            onTransition();
        }
    }

}

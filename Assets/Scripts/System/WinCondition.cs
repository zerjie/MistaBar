using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private bool gameWon = false;

    private void Update()
    {
        if (gameWon==false)
        {
            gameWon = true;
        }
    }
}

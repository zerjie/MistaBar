using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrunkController : MonoBehaviour
{

    bool closedGame = false;
    public void RightObjectClicked()
    {
        if (closedGame == false)
        {
            GameEvents.current.PlayerWin();
            GameEvents.current.CloseGame();
            closedGame = true;
        }

    }
}

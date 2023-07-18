using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrunkController : MonoBehaviour
{
    public void RightObjectClicked()
    {
        GameEvents.current.PlayerWin();
        GameEvents.current.CloseGame();
        //remove timer
    }
}

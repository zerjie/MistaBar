using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrunkController : MonoBehaviour
{
    int pointCount;
    public void RightObjectClicked()
    {
        pointCount++;
        
        if(pointCount == 2)
        {
            GameEvents.current.PlayerWin();
            GameEvents.current.CloseGame();
        }

        //remove timer
    }
}

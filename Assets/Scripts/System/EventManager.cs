using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public MicroGameManager microGameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onPlayerWin += OnPlayerWin;
        GameEvents.current.onPlayerLose += OnPlayerLoss;
        GameEvents.current.onTimeOut += OnTimeOut;
        GameEvents.current.onCloseGame += OnCloseGame;
        GameEvents.current.onTransition += OnTransition;
    }

    private void OnPlayerWin()
    {
        Debug.Log("player win");
    }

    private void OnPlayerLoss()
    {
        Debug.Log("player lose");
    }

    private void OnTimeOut()
    {
        Debug.Log("Time Out");

    }

    private void OnCloseGame()
    {
        Debug.Log("closing game");
        SceneManager.UnloadSceneAsync(microGameManager.selectedMicroGame);
        microGameManager.microGameList.Remove(microGameManager.selectedMicroGame);
        GameEvents.current.Transition();
    }

    private void OnTransition()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public MicroGameManager microGameManager;
    [SerializeField] bool closedGame = false;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onPlayerWin += OnPlayerWin;
        GameEvents.current.onPlayerLose += OnPlayerLoss;
        GameEvents.current.onTimeOut += OnTimeOut;
        GameEvents.current.onOpenGame += OnOpenGame;
        GameEvents.current.onCloseGame += OnCloseGame;
        GameEvents.current.onTransition += OnTransition;
    }

    private void OnPlayerWin()
    {
        Debug.Log("player won!");
        timer.HappyManager();
    }

    private void OnPlayerLoss()
    {
        Debug.Log("player lost!");
    }

    private void OnTimeOut()
    {
        Debug.Log("Time ran out!");

    }

    private void OnOpenGame()
    {
        closedGame = false;
        timer.timeRemaining = 5f;
        timer.HappyManager();
    }
    private void OnCloseGame()
    {
        Debug.Log("closing game");
        if (closedGame == false)
        {
            SceneManager.UnloadSceneAsync(microGameManager.selectedMicroGame);
            microGameManager.microGameList.Remove(microGameManager.selectedMicroGame);
            timer.timeRemaining = 0f;
            closedGame = true;
            GameEvents.current.Transition();
        }
    }

    private void OnTransition()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);

    }
}

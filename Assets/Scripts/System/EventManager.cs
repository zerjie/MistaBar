using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public MicroGameManager microGameManager;
    [SerializeField] bool closedGame = false;
    public GameObject timer;
    public LifeManager lifeManager;
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
        Debug.Log("player won!");
        timer.GetComponent<Timer>().HappyManager(); 
    }

    private void OnPlayerLoss()
    {
        Debug.Log("player lost!");
        lifeManager.LoseLife();
    }

    private void OnTimeOut()
    {
        Debug.Log("Time ran out!");
        lifeManager.LoseLife();

    }

    private void OnOpenGame()
    {
        closedGame = false;
        timer.SetActive(true);
        timer.GetComponent<Timer>().timeRemaining = 5f;
        timer.GetComponent<Timer>().HappyManager();
    }
    private void OnCloseGame()
    {
        if (closedGame == false)
        {
            SceneManager.UnloadSceneAsync(microGameManager.selectedMicroGame);
            microGameManager.microGameList.Remove(microGameManager.selectedMicroGame);
            closedGame = true;
            timer.SetActive(false);
            GameEvents.current.Transition();
        }
    }

    private void OnTransition()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);

    }
}

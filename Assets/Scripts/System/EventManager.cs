using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public MicroGameManager microGameManager;
    [SerializeField] bool closedGame = false;
    public GameObject timer;
    public LifeManager lifeManager;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject instruction3;
    public GameObject instruction1text;
    public float timeForMessage = 2f;
    public float timeFromEnd;

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
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        instruction1.SetActive(true);
        instruction1text.GetComponent<TMP_Text>().text = "SUCCESS!";
        timer.GetComponent<Timer>().HappyManager();
        timeFromEnd += Time.deltaTime;
        if (timeFromEnd >= timeForMessage)
        {
            instruction1.SetActive(false);
        }
    }

    private void OnPlayerLoss()
    {
        Debug.Log("player lost!");
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        instruction1.SetActive(true);
        instruction1text.GetComponent<TMP_Text>().text = "FAILURE!";
        lifeManager.LoseLife();
        timeFromEnd += Time.deltaTime;
        if (timeFromEnd >= timeForMessage)
        {
            instruction1.SetActive(false);
        }
    }

    private void OnTimeOut()
    {
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        instruction1.SetActive(true);
        instruction1text.GetComponent<TMP_Text>().text = "FAILURE!";
        Debug.Log("Time ran out!");
        lifeManager.LoseLife();
        timeFromEnd += Time.deltaTime;
        if (timeFromEnd >= timeForMessage)
        {
            instruction1.SetActive(false);
        }

    }

    private void OnOpenGame()
    {
        closedGame = false;
        timeFromEnd = 0f;
        instruction1.SetActive(false);
        timer.SetActive(true);
        timer.GetComponent<Timer>().timeRemaining = 8f;
        timer.GetComponent<Timer>().HappyManager();
    }
    private void OnCloseGame()
    {
        if (closedGame == false)
        {
            SceneManager.UnloadSceneAsync(microGameManager.selectedMicroGame);
            microGameManager.microGameList.Remove(microGameManager.selectedMicroGame);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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

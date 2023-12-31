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
    public GameObject instruction4;
    public GameObject instruction1text;
    public float timeForMessage = 2f;
    public float timeFromEnd;
    bool gameOver = false;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip sirens;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnPlayerWin += OnPlayerWin;
        GameEvents.current.OnPlayerLose += OnPlayerLoss;
        GameEvents.current.OnTimeOut += OnTimeOut;
        GameEvents.current.OnOpenGame += OnOpenGame;
        GameEvents.current.OnCloseGame += OnCloseGame;
        GameEvents.current.OnTransition += OnTransition;
        GameEvents.current.OnGameOver += OnGameOver;
        GameEvents.current.OnFinishGame += OnFinishGame;
        GameEvents.current.OnPlaySirens += PlaySirens;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnPlayerWin()
    {
        Debug.Log("player won!");
        instruction4.SetActive(false);
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        instruction1.SetActive(true);
        instruction1text.GetComponent<TMP_Text>().text = "SUCCESS!";
        timer.GetComponent<Timer>().HappyManager();
        audioSource.PlayOneShot(winSound);
        timeFromEnd += Time.deltaTime;
        if (timeFromEnd >= timeForMessage)
        {
            instruction1.SetActive(false);
        }
    }

    private void OnPlayerLoss()
    {
        Debug.Log("player lost!");
        instruction4.SetActive(false);
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        instruction1.SetActive(true);
        instruction1text.GetComponent<TMP_Text>().text = "FAILURE!";
        lifeManager.LoseLife();
        audioSource.PlayOneShot(loseSound);
        timeFromEnd += Time.deltaTime;
        if (timeFromEnd >= timeForMessage)
        {
            instruction1.SetActive(false);
        }
    }

    private void OnTimeOut()
    {
        instruction4.SetActive(false);
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        instruction1.SetActive(true);
        instruction1text.GetComponent<TMP_Text>().text = "FAILURE!";
        Debug.Log("Time ran out!");
        lifeManager.LoseLife();
        audioSource.PlayOneShot(loseSound);
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
    private void OnGameOver()
    {
        if (!gameOver)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
            instruction1.SetActive(true);
            instruction1text.GetComponent<TMP_Text>().text = "GAME OVER!";
            gameOver = true;
        }
    }

    private void OnFinishGame()
    {
        if (!gameOver)
        {
            SceneManager.LoadScene(10, LoadSceneMode.Additive);
            instruction1.SetActive(true);
            instruction1text.GetComponent<TMP_Text>().text = "JOB DONE!";
            gameOver = true;
        }
    }

    private void PlaySirens()
    {
        audioSource.PlayOneShot(sirens);
    }
}

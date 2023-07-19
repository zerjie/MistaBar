using UnityEngine;
using UnityEngine.UI;

public class Muddling : MonoBehaviour
{
    // Change depending on UI Manager
    [Header("UI")]
    public GameObject instruction;
    public Text counterText;
    public int counter;

    //public float timer;
    //private float _timer;
    //public GameObject timerbar;
    //private float scalextb;

    //[SerializeField] Text counterUI;

    [Header("Shaking")]
    public float mashDelay = 0.5f;
    public GameObject shaker;

    private float mash;
    bool pressed;
    float shakesToWin = 30;

    bool callOnce;

    // Start is called before the first frame update
    void Start()
    {
        //scalextb = timerbar.transform.localScale.x;

        mash = mashDelay;
        //_timer = timer;

        //Countdown();

        // Change later depending on UI
        instruction.SetActive(true);
    }

    void Update()
    {
        counterText.text = counter.ToString() + "/50";
        GameStart();

    }

    public void GameStart()
    {
        if (!callOnce)
        {
            //timerbar.transform.localScale = new Vector2(scalextb * (_timer / timer), timerbar.transform.localScale.y);
            mash -= Time.deltaTime;
            //_timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && !pressed)
            {
                pressed = true;
                mash = mashDelay;



            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                pressed = false;
                counter++;

                // Change later depending on UI
                instruction.SetActive(false);

                if (counter % 2 == 0)
                {
                    shaker.transform.position = new Vector3(-1.32f, -0.8f, 0.0f);
                }

                else
                {
                    shaker.transform.position = new Vector3(1.5f, 1.3f, 1.0f);
                }
            }

            if (counter >= shakesToWin)
            {
                WinCondition();
            }

            else
            {
                LoseCondition();
            }

            /*if (_timer <= 0)
            {
                if (counter < 30)
                {
                    LoseCondition();
                }
                else
                {
                    WinCondition();
                }

                _timer = 0;
                callOnce = true;
            }
            */
        }
    }
    public void WinCondition()
    {
        GameEvents.current.PlayerWin();
        /*instruction.GetComponent<Text>().text = "Win";
        instruction.SetActive(true);
        shaker.SetActive(false);
        Debug.Log("Player Succeeded");
        instruction.transform.position = new Vector3(0f, 0f, 0f);
        */
        // Insert positive game end here to return to UI and Game Manager
        GameEvents.current.CloseGame();
    }

    public void LoseCondition()
    {
        GameEvents.current.PlayerLose();
        /*instruction.GetComponent<Text>().text = "FAILED";
        instruction.SetActive(true);
        shaker.SetActive(false);
        Debug.Log("Microgame Over");
        instruction.transform.position = new Vector3(0f, 0f, 0f);
        // Insert negative game end here to return to UI and Game Manager
        */
        GameEvents.current.CloseGame();
    }
}

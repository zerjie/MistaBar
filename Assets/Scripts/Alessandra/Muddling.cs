using UnityEngine;
using UnityEngine.UI;

public class Muddling : MonoBehaviour
{
    // Change depending on UI Manager
    [Header("UI")]
    public GameObject instruction;
    public Text counterText;
    public int counter;

    [Header("Muddling")]
    public float mashDelay = 0.5f;
    public GameObject muddler;
    public Audio muddleAudio;

    private float mash;
    bool pressed;
    float muddlesToWin = 60;

    // Start is called before the first frame update
    void Start()
    {
        mash = mashDelay;

        // Change later depending on UI
        instruction.SetActive(true);
    }

    void Update()
    {
        counterText.text = counter.ToString() + "/60";
        GameStart();
    }

    public void GameStart()
    {
        mash -= Time.deltaTime;
   
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
                muddlerDown();
            }

            else
            {
                muddlerUp();
            }

            // Play shake audio
            muddleAudio.PlayRandomMuddle();
        }

        if (counter >= muddlesToWin)
        {
            WinCondition();
        }

        else
        {
            LoseCondition();
        }
    }
    public void WinCondition()
    {
        GameEvents.current.PlayerWin();
        GameEvents.current.CloseGame();
    }

    public void LoseCondition()
    {
        GameEvents.current.PlayerLose();
        GameEvents.current.CloseGame();
    }

    public void muddlerDown()
    {
        muddler.transform.position = new Vector3(-0.15f, -2.09f, 1.0f);
     
    }

    public void muddlerUp()
    {
        muddler.transform.position = new Vector3(-0.13f, 2.93f, 1.0f);

    }
}

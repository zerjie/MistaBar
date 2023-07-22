using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneGameController : MonoBehaviour
{

    [SerializeField] TMP_Text numberDislay;
    string enteredNumbers;
    public AudioClip buttonPress;
    public AudioClip sirens;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        numberDislay.text = enteredNumbers;
        if (enteredNumbers == "911")
        {
            Debug.Log("Help arriving!");
            GameEvents.current.PlayerWin();
            GameEvents.current.CloseGame();
            GameEvents.current.PlaySirens();
            audioSource.PlayOneShot(sirens);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }


    }



    public void Add1()
    {
        enteredNumbers += "1";
        audioSource.PlayOneShot(buttonPress);
    }

    public void Add2()
    {
        enteredNumbers += "2";
        PlayerLose();
        audioSource.PlayOneShot(buttonPress);
        Debug.Log("Wrong Number!");
    }

    public void Add3()
    {
        enteredNumbers += "3";
        PlayerLose();
        audioSource.PlayOneShot(buttonPress);
        Debug.Log("Wrong Number!");
    }

    public void Add4()
    {
        enteredNumbers += "4";
        PlayerLose();
        audioSource.PlayOneShot(buttonPress);
        Debug.Log("Wrong Number!");
    }

    public void Add5()
    {
        enteredNumbers += "5";
        PlayerLose();
        audioSource.PlayOneShot(buttonPress);
        Debug.Log("Wrong Number!");
    }

    public void Add6()
    {
        enteredNumbers += "6";
        PlayerLose();
        audioSource.PlayOneShot(buttonPress);
        Debug.Log("Wrong Number!");
    }

    public void Add7()
    {
        enteredNumbers += "7";
        PlayerLose();
        audioSource.PlayOneShot(buttonPress);
        Debug.Log("Wrong Number!");
    }

    public void Add8()
    {
        enteredNumbers += "8";
        PlayerLose();
        audioSource.PlayOneShot(buttonPress);
        Debug.Log("Wrong Number!");
    }
    public void Add9()
    {
        enteredNumbers += "9";
        audioSource.PlayOneShot(buttonPress);

    }

    private void PlayerLose()
    {
        GameEvents.current.PlayerWin();
        GameEvents.current.CloseGame();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

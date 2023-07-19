using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneGameController : MonoBehaviour
{

    [SerializeField] TMP_Text numberDislay;
    [SerializeField] TMP_Text commandText;
    string enteredNumbers;



    // Start is called before the first frame update
    void Start()
    {

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
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }


    }



    public void Add1()
    {
        enteredNumbers += "1";
    }

    public void Add2()
    {
        enteredNumbers += "2";
        PlayerLose();
        Debug.Log("Wrong Number!");
    }

    public void Add3()
    {
        enteredNumbers += "3";
        PlayerLose();
        Debug.Log("Wrong Number!");
    }

    public void Add4()
    {
        enteredNumbers += "4";
        PlayerLose();
        Debug.Log("Wrong Number!");
    }

    public void Add5()
    {
        enteredNumbers += "5";
        PlayerLose();
        Debug.Log("Wrong Number!");
    }

    public void Add6()
    {
        enteredNumbers += "6";
        PlayerLose();
        Debug.Log("Wrong Number!");
    }

    public void Add7()
    {
        enteredNumbers += "7";
        PlayerLose();
        Debug.Log("Wrong Number!");
    }

    public void Add8()
    {
        enteredNumbers += "8";
        PlayerLose();
        Debug.Log("Wrong Number!");
    }
    public void Add9()
    {
        enteredNumbers += "9";
        
    }

    private void PlayerLose()
    {
        GameEvents.current.PlayerWin();
        GameEvents.current.CloseGame();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

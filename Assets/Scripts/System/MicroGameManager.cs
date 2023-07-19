using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MicroGameManager : MonoBehaviour
{
    public List<int> microGameList;

    public int selectedIndex;
    public int selectedMicroGame;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject instruction3;
    public GameObject instruction1text;
    public GameObject instruction2text;
    public GameObject instruction3text;
    private static MicroGameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static MicroGameManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        selectedIndex = Random.Range(0, microGameList.Count);
        selectedMicroGame = microGameList[selectedIndex];
        OpenMicroGame(selectedMicroGame);

    }
    //randomly selects a minigame
    public void NewRandomMicroGame()
    {
        selectedIndex = Random.Range(0, microGameList.Count);
        selectedMicroGame = microGameList[selectedIndex];
        OpenMicroGame(selectedMicroGame);
        GameEvents.current.OpenGame();
        
        Debug.Log("Opening Microgame: " + selectedMicroGame);
    }
    public void OpenMicroGame(int microGameIndex)
    {
        // Load the scene or activate game objects based on the mini-game name
        switch (selectedMicroGame)
        {
            case 3:
                instruction1.SetActive(true);
                instruction1text.GetComponent<TMP_Text>().text = "GARNISH!";
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                selectedMicroGame = 3;
                break;

            case 4:
                instruction2.SetActive(true);
                instruction2text.GetComponent<TMP_Text>().text = "CALL 911!";
                SceneManager.LoadScene(4, LoadSceneMode.Additive);
                selectedMicroGame = 4;
                break;

            case 5:
                instruction3.SetActive(true);
                instruction3text.GetComponent<TMP_Text>().text = "APPLES!";
                SceneManager.LoadScene(5, LoadSceneMode.Additive);
                selectedMicroGame = 5;
                break;

            case 6:
                instruction3.SetActive(true);
                instruction3text.GetComponent<TMP_Text>().text = "WHO'S DRUNK?";
                SceneManager.LoadScene(6, LoadSceneMode.Additive);
                selectedMicroGame = 6;
                break;

            case 7:
                instruction1.SetActive(true);
                instruction1text.GetComponent<TMP_Text>().text = "DODGE!";
                SceneManager.LoadScene(7, LoadSceneMode.Additive);
                selectedMicroGame = 7;
                break;
            case 8:
                instruction3.SetActive(true);
                instruction3text.GetComponent<TMP_Text>().text = "SHAKE!";
                SceneManager.LoadScene(8, LoadSceneMode.Additive);
                selectedMicroGame = 8;
                break;


            // Add more cases for other mini-games

            default:
                Debug.LogWarning("Mini-game not found: " + microGameIndex);
                break;
        }
    }


}
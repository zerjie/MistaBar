using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MicroGameManager : MonoBehaviour
{
    public List<int> microGameList;

    public int selectedIndex;
    public int selectedMicroGame;

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
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                selectedMicroGame = 3;
                break;

            case 4:
                SceneManager.LoadScene(4, LoadSceneMode.Additive);
                selectedMicroGame = 4;
                break;

            case 5:
                SceneManager.LoadScene(5, LoadSceneMode.Additive);
                selectedMicroGame = 5;
                break;

            case 6:
                SceneManager.LoadScene(6, LoadSceneMode.Additive);
                selectedMicroGame = 6;
                break;


            // Add more cases for other mini-games

            default:
                Debug.LogWarning("Mini-game not found: " + microGameIndex);
                break;
        }
    }


}
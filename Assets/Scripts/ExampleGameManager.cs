using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleGameManager : MonoBehaviour
{

    // To ensure that there's no conflicts on loading, we tell the SceneSwapper to load our scenes from Start here, to prevent script load execution errors
    void Start()
    {
        //Tell SceneSwapper to load the starting UI
        SceneSwapper.instance.LoadStartingUI();
        SelectScene("MainMenu");

        // If player presses the play button, start game

    }

    public void PlayGame()
    {
        // Have a cut scene showing the instructions here
        // Fade in and fade out optional 
        RandomSelectScene();
        EditorSceneManager.CloseScene(SceneManager.GetSceneByName("MainMenu"), true);
    }

    public void RandomSelectScene()
    {
        int random = Random.Range(0, SceneSwapper.instance.gameScenes.Length);

        //Also tell SceneSwapper to load the game scene at position 0
        SceneSwapper.instance.LoadScene(random);
    }

    public void SelectScene(string sceneName)
    {
        SceneSwapper.instance.LoadUnloadScene(sceneName);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneSwapper.instance.LoadUnloadScene(SceneSwapper.instance.CurrentScene);
            RandomSelectScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting Now");
            Application.Quit();
        }
    }
}

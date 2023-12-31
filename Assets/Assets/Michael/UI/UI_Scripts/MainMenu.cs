using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource bgm;

    private void Start()
    {
        // Get the AudioSource component attached to the "AudioObject" GameObject
        //bgm = GameObject.Find("AudioObject").GetComponent<AudioSource>();

        // Check if the AudioSource and AudioClip are set
        if (bgm != null && bgm.clip != null)
        {
            // Play the audio clip in a loop
            bgm.Play();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void OnClick()
    {
        MicroGameManager.GetInstance().NewRandomMicroGame();
        SceneManager.UnloadSceneAsync(2);
    }

    public void EndGame()
    {
        SceneManager.UnloadSceneAsync(10);
        SceneManager.LoadScene(0);
    }

}

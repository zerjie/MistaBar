using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 5;
    public GameObject gameOverScreen;

    private int currentLives;
    private bool isGameOver = false;

    void Start()
    {
        currentLives = maxLives;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            currentLives--;
            Debug.Log("Player Lives: " + currentLives);

            if (currentLives <= 0)
            {
                GameOver();
            }
            else
            {
                Respawn();
            }
        }
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over");     
        isGameOver = true;
        ObjectSpawner objectSpawner = FindObjectOfType<ObjectSpawner>();
        objectSpawner.SetGameOver(true);
    }

    void Respawn()
    {
        // Implement player respawn logic here
    }
}
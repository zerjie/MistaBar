using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int maxBottles = 5;
    public GameObject gameOverScreen;
    public GameObject bottleContainer;

    private int currentBottles;
    private bool isGameOver = false;

    private List<BottleFalling> bottles;

    void Start()
    {
        InitializeBottles();
        currentBottles = maxBottles;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            LoseBottle();
        }
    }

    void LoseBottle()
    {
        if (currentBottles > 0)
        {
            currentBottles--;
            Debug.Log("Remaining Bottles: " + currentBottles);

            if (currentBottles == 0)
            {
                GameOver();
                MakeBottleFall();
            }
            else
            {
                int bottleIndex = maxBottles - currentBottles - 1;
                BottleFalling bottleFalling = bottles[bottleIndex];
                bottleFalling.StartFalling();
            }
        }
    }

    void InitializeBottles()
    {
        bottles = new List<BottleFalling>();

        for (int i = 0; i < bottleContainer.transform.childCount; i++)
        {
            BottleFalling bottleFalling = bottleContainer.transform.GetChild(i).GetComponent<BottleFalling>();
            bottles.Add(bottleFalling);
        }
    }

    void MakeBottleFall()
    {
        if (currentBottles > 0)
        {
            int bottleIndex = maxBottles - currentBottles;
            BottleFalling bottleFalling = bottles[bottleIndex];
            if (!bottleFalling.IsFalling())
            {
                bottleFalling.StartFalling();
            }
        }
        else if (currentBottles == 0)
        {
            int lastBottleIndex = bottles.Count - 1;
            BottleFalling lastBottleFalling = bottles[lastBottleIndex];
            lastBottleFalling.StartFalling(); // Make the last bottle fall unconditionally
        }
    }



    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over");
        isGameOver = true;
        DrunkardSpawner drunkardSpawner = FindObjectOfType<DrunkardSpawner>();
        drunkardSpawner.SetGameOver(true);
    }

    void Respawn()
    {
        // Implement player respawn logic here
    }
}
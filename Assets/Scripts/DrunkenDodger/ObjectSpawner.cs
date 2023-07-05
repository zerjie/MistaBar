using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("SpawnSettings")]
    public GameObject objectPrefab;
    public float spawnInterval = 1f;
    public float spawnIncreaseRate = 0.1f;
    public float spawnRange = 3f;


    private float spawnTimer = 0f;
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
            spawnInterval -= spawnIncreaseRate;
            spawnInterval = Mathf.Max(spawnInterval, 0.1f);
        }
    }

    void SpawnObject()
    {
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, 0f);
        GameObject spawnedObject = Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }

    public void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class DrunkardSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnInterval = 1f;
    public float spawnIncreaseRate = 0.1f;
    public float spawnRange = 3f;
    public float initialScale = 2f;

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
        GameObject prefab = objectPrefabs[UnityEngine.Random.Range(0, objectPrefabs.Length)];
        float spawnX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        float spawnY = Camera.main.orthographicSize + 1f;
        Vector3 randomPosition = new Vector3(spawnX, spawnY, 0f);

        GameObject spawnedObject = Instantiate(prefab, randomPosition, Quaternion.identity);

        // Set the scale of the spawned object
        ObjectMovement objectMovement = spawnedObject.GetComponent<ObjectMovement>();
        if (objectMovement != null)
        {
            objectMovement.initialScale = initialScale;
        }
    }

    public void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }
}
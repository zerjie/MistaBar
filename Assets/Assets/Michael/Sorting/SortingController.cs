using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SortingController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] clickableObjects;
    public GameObject[] spawnedObjects;
    int correctSpawnIndex;
    public int pointCount;
    public int rightObjects;


    // Start is called before the first frame update
    void Start()
    {
        rightObjects = 0;
        pointCount = 0;
        //Set array size
        spawnedObjects = new GameObject[spawnPoints.Length];

        // Select a random index for the correct object
        correctSpawnIndex = Random.Range(0, spawnPoints.Length);

        InstantiateGameObjects();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointCount == spawnPoints.Length)
        {
            GameEvents.current.PlayerWin();
            GameEvents.current.CloseGame();
            Debug.Log("Sorting game win!");
        }
    }

    void InstantiateGameObjects()
    {
        Scene gameScene = SceneManager.GetSceneByName("Sorting");

        for (int i = 0; i < spawnPoints.Length; i++)
        {

            // Select a random object prefab (excluding the correct object)
            GameObject randomObjectPrefab = clickableObjects[Random.Range(0, clickableObjects.Length)];

            // Instantiate the random object at the spawn point
            GameObject spawnedObject = Instantiate(randomObjectPrefab, spawnPoints[i].position, Quaternion.identity);

            // Set the object's scene explicitly
            SceneManager.MoveGameObjectToScene(spawnedObject, gameScene);


            spawnedObjects[i] = spawnedObject;
        }
    }



}

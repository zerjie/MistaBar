using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickIngredientsController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] clickableObjects;
    string tagToCount = "RightObject";
    public GameObject[] spawnedObjects;
    public GameObject spawnedObject;
    public GameObject rightObject;
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
        CountRightObjects();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointCount == rightObjects)
        {
            Debug.Log("You Win!");
        }
    }

    void InstantiateGameObjects()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Skip the correct object spawn index
            if (i == correctSpawnIndex)
                continue;

            // Select a random object prefab (excluding the correct object)
            GameObject randomObjectPrefab = clickableObjects[Random.Range(0, clickableObjects.Length)];

            // Instantiate the random object at the spawn point
            GameObject spawnedObject = Instantiate(randomObjectPrefab, spawnPoints[i].position, Quaternion.identity);


            spawnedObjects[i] = spawnedObject;
        }

        // Spawn the correct object at the reserved spawn point
        spawnedObjects[correctSpawnIndex] = Instantiate(rightObject, spawnPoints[correctSpawnIndex].position, Quaternion.identity);
    }

    

    public void RightObjectClicked( )
    {
        pointCount++;
        Debug.Log("Clicked object: " );
    }

    public void WrongObjectClicked()
    {
        Debug.Log("Wrong object clicked ");
    }


    private void CountRightObjects()
    {


        foreach (GameObject obj in spawnedObjects)
        {
            if (obj.CompareTag(tagToCount))
            {
                rightObjects++;
            }
        }

        Debug.Log("Number of objects with tag '" + tagToCount + "': " + rightObjects);
    }

}

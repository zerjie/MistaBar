using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PickIngredientController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] clickableObjects;
    string tagToCount = "RightObject";
    public GameObject[] spawnedObjects;
    public GameObject spawnedObject;
    public GameObject rightObject;
    int correctSpawnIndex;
    bool closedGame = false;
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

        closedGame = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (pointCount == rightObjects && rightObjects != 0 && closedGame == false)
        {
            GameEvents.current.PlayerWin();
            GameEvents.current.CloseGame();
            closedGame = true;
        }
    }

    void InstantiateGameObjects()
    {
        Scene gameScene = SceneManager.GetSceneByName("PickIngredient");

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Skip the correct object spawn index
            if (i == correctSpawnIndex)
                continue;

            // Select a random object prefab (excluding the correct object)
            GameObject randomObjectPrefab = clickableObjects[Random.Range(0, clickableObjects.Length)];

            // Instantiate the random object at the spawn point
            GameObject spawnedObject = Instantiate(randomObjectPrefab, spawnPoints[i].position, Quaternion.identity);

            // Set the object's scene explicitly
            SceneManager.MoveGameObjectToScene(spawnedObject, gameScene);


            spawnedObjects[i] = spawnedObject;
        }

        // Instantiate and set the scene for the correct object at the reserved spawn point
        GameObject correctObject = Instantiate(rightObject, spawnPoints[correctSpawnIndex].position, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(correctObject, gameScene);
        spawnedObjects[correctSpawnIndex] = correctObject;
    }

    

    public void RightObjectClicked( )
    {
        //add to point counter
        pointCount++;
        Debug.Log("Right object clicked: " +pointCount);
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

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
    public List<GameObject> spawnedObjects;
    public GameObject spawnedObject;
    public int pointCount;
    public int rightObjects;

    // Start is called before the first frame update
    void Start()
    {
        rightObjects = 0;
        pointCount = 0;
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
            GameObject randomObjectPrefab = clickableObjects[Random.Range(0, clickableObjects.Length)];
            spawnedObject = Instantiate(randomObjectPrefab, spawnPoints[i].position, Quaternion.identity);
            spawnedObjects.Add(spawnedObject);
        } 
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

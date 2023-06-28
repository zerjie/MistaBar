using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabClick : MonoBehaviour
{
    [SerializeField] GameObject gameController;
   public int pointCounter;

    public void Start()
    {
        pointCounter = gameController.GetComponent<PickIngredientsController>().pointCount;
    }
   public void OnPrefabClicked()
    {

            pointCounter++;
        Debug.Log("Obj clicked");
    }
}

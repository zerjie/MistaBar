using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class Dartboard : MonoBehaviour
//{
//    [SerializeField] private string nextSceneName;

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Dart"))
//        {
//            DartMovement dartMovement = other.GetComponent<DartMovement>();
//            if (dartMovement != null && !dartMovement.isMoving)
//            {
//                Debug.Log("Hit the bullseye!");


//                SceneManager.LoadScene(nextSceneName);
//            }
//            else
//            {
//                Debug.Log("Dart is moving not a bullseye.");
//            }
//        }
//    }
//}

public class Dartboard : MonoBehaviour
{
    private GameEvents gameEvents;

    private void Start()
    {
        // Assign the GameEvents script here
        gameEvents = FindObjectOfType<GameEvents>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Dart"))
        {
            DartMovement dartMovement = other.GetComponent<DartMovement>();
            if (dartMovement != null && !dartMovement.isMoving)
            {
                Debug.Log("Hit the bullseye!");

                // Trigger the win logic
                if (gameEvents != null)
                {
                    gameEvents.PlayerWin();
                }
            }
            else
            {
                Debug.Log("Dart is moving not a bullseye.");
            }
        }
    }
}


//GameEvents.current.PlayerWin();
//GameEvents.current.CloseGame();


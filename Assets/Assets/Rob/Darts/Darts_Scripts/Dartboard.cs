using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject gameOverScreen;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Dart"))
        {
            DartMovement dartMovement = other.GetComponent<DartMovement>();
            if (dartMovement != null && !dartMovement.isMoving)
            {
                Debug.Log("Hit the bullseye!");

                // Trigger the game over logic here
                GameOver();
            }
            else
            {
                Debug.Log("Dart is moving not a bullseye.");
            }
        }
    }

    void GameOver()
    {      
        gameOverScreen.SetActive(true);
        GameEvents.current.PlayerLose();
        GameEvents.current.CloseGame();       
        
    }
}


//GameEvents.current.PlayerWin();
//GameEvents.current.CloseGame();


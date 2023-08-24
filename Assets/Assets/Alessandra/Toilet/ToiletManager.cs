using UnityEngine;
using UnityEngine.UI;

public class Toilet : MonoBehaviour
{
    ToiletGame game;

    private GameObject[] frogObjects;

    void Start()
    {
       game = GameObject.FindGameObjectWithTag("ToiletGame").GetComponent<ToiletGame>();

       frogObjects = GameObject.FindGameObjectsWithTag("Frog");

        foreach (var var in frogObjects)
        {
            var.GetComponent<BezierFollow>().enabled = false;
        }
    }
    

    void Update()
    {
        game.GameStart();

        if (game.frogsEscape == true)
        {

            foreach (var var in frogObjects)
            {
                var.GetComponent<BezierFollow>().enabled = true;
            }
        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public int counter;

    public GameObject shaker;

    float counterWin;
    bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    void GameStart()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !pressed)
        {
            pressed = true;
            
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            pressed = false;
            counter++;

            if(counter % 2 == 0)
            {
                shaker.transform.position = new Vector3(-1.32f, -0.8f, 0.0f);
            }
        }

        else
        {
            shaker.transform.position = new Vector3(1.5f, 1.3f, 1.0f);
        }
    }

}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakingMicrogameScript : MonoBehaviour
{

    public float mashDelay = 0.5f;
    public GameObject text;
    public int counter;
    public GameObject shaker;

    float mash;
    bool pressed;
    bool started;

    // Start is called before the first frame update
    void Start()
    {
        mash = mashDelay;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            started = true;
        }

        if(started)
        {
            text.SetActive(true);
            mash -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && !pressed)
            {
                pressed = true;
                mash = mashDelay;
            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                pressed = false;
                counter++;

                if (counter % 2 == 0)
                {
                    shaker.transform.position = new Vector3(-1.32f, -0.8f, 0.0f);
                }

                else
                {
                    shaker.transform.position = new Vector3(1.5f, 1.3f, 0.0f);
                }
            }

            if (mash <=0)
            {
                text.GetComponent<Text>().text = "FAILED";
                Debug.Log("Microgame failed");
            }
        }
    }

}

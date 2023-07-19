using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DD_tutorial : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private float flashInterval = 0.5f;
    private int flashCount = 6;
    private float timer = 0f;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        InvokeRepeating("Flash Text", 0f, flashInterval);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            textComponent.enabled = false; Destroy(this);
        }

    }

    private void FlashText()
    {
        textComponent.enabled = !textComponent.enabled;
        flashCount--;
        if (flashCount <= 0)

            CancelInvoke("FlashText");
        textComponent.enabled = true;
    }
}



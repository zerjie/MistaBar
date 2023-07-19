using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DD_tutorial : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private float flashInterval = 0.15f;
    private int flashCount = 6;
    private float timer = 0f;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        StartCoroutine(FlashTextRoutine());
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            textComponent.enabled = false;
            Destroy(this);
        }

    }

    private System.Collections.IEnumerator FlashTextRoutine()
    {
        while (flashCount > 0)
        {
            textComponent.enabled = !textComponent.enabled;
            yield return new
                WaitForSeconds(flashInterval);
            flashCount--;
        }

        textComponent.enabled = true;

    }
}
    


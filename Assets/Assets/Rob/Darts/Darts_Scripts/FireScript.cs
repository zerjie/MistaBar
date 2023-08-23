using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] private GameObject dartPrefab;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private float dartSpeed = 10.0f;

    [SerializeField] private GameObject handObject;
    [SerializeField] private float maxHandSize = 1.5f;
    [SerializeField] private float scaleSpeed = 0.1f;

    private bool isFiring = false;
    private Vector3 initialHandScale;

    private void Start()
    {
        initialHandScale = handObject.transform.localScale;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isFiring = true;
        }

        if (Input.GetButtonUp("Fire1") && isFiring)
        {
            FireDart();
            isFiring = false;
        }

        UpdateHandSize();
    }

    private void FireDart()
    {
        Vector3 crosshairPosition = crosshair.transform.position;

        GameObject dart = Instantiate(dartPrefab, transform.position, Quaternion.identity);

        DartMovement dartMovement = dart.GetComponent<DartMovement>();
        if (dartMovement != null)
        {
            dartMovement.SetTarget(crosshairPosition, dartSpeed);
        }
    }
    private void UpdateHandSize()
    {
        if (isFiring)
        {
            Vector3 newScale = initialHandScale * maxHandSize;
            handObject.transform.localScale = Vector3.Lerp(handObject.transform.localScale, newScale, scaleSpeed * Time.deltaTime);
        }
        else
        {
            handObject.transform.localScale = Vector3.Lerp(handObject.transform.localScale, initialHandScale, scaleSpeed * Time.deltaTime);
        }
    }
}


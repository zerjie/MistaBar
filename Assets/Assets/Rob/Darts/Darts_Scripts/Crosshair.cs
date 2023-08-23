using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        Vector3 crosshairPosition = target.position + offset;
        transform.position = crosshairPosition;
    }
}
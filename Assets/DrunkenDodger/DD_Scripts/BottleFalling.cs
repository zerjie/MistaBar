using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFalling : MonoBehaviour
{
    public float fallSpeed = 6f;
    public float maxRotationAngle = 20f;
    public float rotationSpeed = 15f;

    private bool isFalling = false;
    private Quaternion targetRotation;

    public bool IsFalling()
    {
        return isFalling;
    }

    void Start()
    {
        targetRotation = Quaternion.Euler(0f, 0f, Random.Range(-maxRotationAngle, maxRotationAngle));
    }

    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (transform.position.y < -10f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartFalling()
    {
        isFalling = true;
    }
}
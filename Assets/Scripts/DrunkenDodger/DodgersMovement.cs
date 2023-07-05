using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgersMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float characterWidth;

    [Header("Screen Settings")]
    [SerializeField] private float leftScreenBorder;
    [SerializeField] private float rightScreenBorder;

    private void Start()
    {
        CalculateScreenBorders();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float newPositionX = transform.position.x + moveInput * moveSpeed * Time.deltaTime;
        float clampedX = Mathf.Clamp(newPositionX, leftScreenBorder, rightScreenBorder);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void CalculateScreenBorders()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenRatio;

        characterWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        leftScreenBorder = Camera.main.transform.position.x - cameraWidth / 2 + characterWidth / 2;
        rightScreenBorder = Camera.main.transform.position.x + cameraWidth / 2 - characterWidth / 2;
    }
}
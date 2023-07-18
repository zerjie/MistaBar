using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float characterWidth;

    [Header("Screen Settings")]
    [SerializeField] private float leftScreenBorder;
    [SerializeField] private float rightScreenBorder;

    [Header("Bump Effect Settings")]
    [SerializeField] private float bumpDistance = 0.2f;
    [SerializeField] private float bumpDuration = 0.2f;
    private bool isBumping = false;
    private float bumpTimer = 0f;
    private Vector3 bumpStartPosition;

    private Vector3 initialPosition;

    private void Start()
    {
        CalculateScreenBorders();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isBumping)
        {
            BumpEffect();
        }

        float moveInput = Input.GetAxis("Horizontal");
        float newPositionX = transform.position.x + moveInput * moveSpeed * Time.deltaTime;
        float clampedX = Mathf.Clamp(newPositionX, leftScreenBorder, rightScreenBorder);
        float currentY = transform.position.y;
        transform.position = new Vector3(clampedX, currentY, transform.position.z);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartBumpEffect();
        }
    }

    private void StartBumpEffect()
    {
        isBumping = true;
        bumpTimer = 0f;
        bumpStartPosition = transform.position;
    }

    private void BumpEffect()
    {
        bumpTimer += Time.deltaTime;

        if (bumpTimer <= bumpDuration)
        {
            float t = bumpTimer / bumpDuration;
            float yOffset = Mathf.Sin(t * Mathf.PI * 2f) * bumpDistance * (1f - t);
            Vector3 bumpOffset = new Vector3(0f, yOffset, 0f);
            transform.position = bumpStartPosition + bumpOffset;
        }
        else
        {
            isBumping = false;
        }
    }
}
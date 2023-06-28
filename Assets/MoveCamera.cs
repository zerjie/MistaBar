using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float horizontalLimit = 5f;

    private void Update()
    {
        // Get the mouse movement
        float mouseMovementX = Input.GetAxis("Mouse X");

        // Calculate the new position of the camera
        Vector3 newPosition = transform.position + new Vector3(mouseMovementX * movementSpeed, 0f, 0f);

        // Apply horizontal limits to the camera movement
        newPosition.x = Mathf.Clamp(newPosition.x, -horizontalLimit, horizontalLimit);

        // Update the camera position
        transform.position = newPosition;
    }
}
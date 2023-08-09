using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public float radius = 1.0f;         // Adjust the radius of the circular motion
    public float angularSpeed = 1.0f;   // Adjust the angular speed of the circular motion
    public float sensitivity = 2.0f;    // Adjust the sensitivity of the crosshair movement

    private Vector3 initialPosition;
    private float time = 0.0f;

    private void Start()
    {
        // Store the initial position of the cursor
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Increment time
        time += Time.deltaTime;

        // Calculate the new position of the cursor using circular motion equations
        float circularX = radius * Mathf.Cos(time * angularSpeed);
        float circularY = radius * Mathf.Sin(time * angularSpeed);

        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the z-coordinate to 0 to keep the cursor on the 2D plane
        worldMousePosition.z = 0f;

        // Combine circular motion with mouse movement
        Vector3 combinedPosition = initialPosition + new Vector3(circularX, circularY, 0f) + (worldMousePosition - initialPosition) * sensitivity;

        // Update the cursor's position
        transform.position = combinedPosition;
    }
}
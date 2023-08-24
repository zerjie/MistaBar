using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CursorAim : MonoBehaviour
{
    private float minY = 0.0f;
    private float maxY = -5.0f;

    public float swaySpeedX = 1.0f;  
    public float swaySpeedY = 2.0f;
    public float swayAmount = 0.2f;

    private float initialY;

    private void Start()
    {
        initialY = transform.position.y;
    }

    private void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;

        float xOffset = Mathf.Sin(Time.time * swaySpeedX) * swayAmount;
        float yOffset = Mathf.Sin(Time.time * swaySpeedY) * swayAmount;

        Vector3 swayOffset = new Vector3(xOffset, yOffset, 0);
        Vector3 finalPosition = mouseWorldPosition + swayOffset;

        Vector2 cameraMin = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 cameraMax = Camera.main.ViewportToWorldPoint(Vector2.one);

        finalPosition.x = Mathf.Clamp(finalPosition.x, cameraMin.x, cameraMax.x);
        finalPosition.y = Mathf.Clamp(finalPosition.y, maxY, minY);

        transform.position = finalPosition;
    }
}
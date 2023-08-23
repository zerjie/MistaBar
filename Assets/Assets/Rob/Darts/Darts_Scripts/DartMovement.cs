using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMovement : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.0f;

    public bool isMoving = false;

    private Vector3 initialPosition;
    private float initialDistanceToTarget;

    private void Start()
    {
        initialPosition = transform.position;
        initialDistanceToTarget = Vector3.Distance(initialPosition, targetPosition);
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        float normalizedDistance = Mathf.Clamp01((initialDistanceToTarget - distanceToTarget) / initialDistanceToTarget);

        float currentScale = Mathf.Lerp(maxScale, minScale, normalizedDistance);

        transform.localScale = new Vector3(currentScale, currentScale, 1.0f);

        if (distanceToTarget > 0.01f)
        {
            transform.position += (targetPosition - transform.position).normalized * scaleSpeed * Time.deltaTime;
            isMoving = true; 
        }
        else
        {
            isMoving = false; 
        }
    }

    public void SetTarget(Vector3 target, float spd)
    {
        targetPosition = target;
        scaleSpeed = spd;
    }
    public bool IsMoving()
    {
        return isMoving;
    }


}
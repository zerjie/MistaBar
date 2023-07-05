using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkardMovement : MonoBehaviour
{

    [Header("ObjectMovementSettings")]

    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float finalScale = 2f;
    [SerializeField] private float initialScale = 0.5f;
    [SerializeField] private float maxHeight = 10f;

    
    private Vector3 moveDirection;
    private Transform playerTransform;

    void Start()
    {      
        moveSpeed = Random.Range(minSpeed, maxSpeed);       
        moveDirection = new Vector3(Random.Range(-1f, 1f), -1f, 0f).normalized;      
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;       
        transform.localScale = new Vector3(initialScale, initialScale, 1f);
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
              
        float distanceToPlayer = Mathf.Abs(transform.position.y - playerTransform.position.y);
        float t = Mathf.Clamp01(distanceToPlayer / maxHeight);
        float scale = Mathf.Lerp(finalScale, initialScale, t);  
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
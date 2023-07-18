using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite[] walkingFrames;
    private int currentFrameIndex = 0;
    private float frameRate = 0.2f;
    private float frameTimer = 0f;

    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float initialScale = 0.5f;
    public float finalScale = 2f;
    public float maxHeight = 10f;

    private float moveSpeed;
    private Vector3 moveDirection;
    private UnityEngine.Transform playerTransform;

    void Start()
    {
        moveSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        moveDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), -1f, 0f).normalized;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.localScale = new Vector3(initialScale, initialScale, 1f);

        GetComponent<SpriteRenderer>().sprite = walkingFrames[currentFrameIndex];
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;


        {
            if (transform.position.y < -10f)
            {
                Destroy(transform.parent.gameObject); // Destroy the parent game object
            }
        

        }

            if (walkingFrames.Length > 0)
        {
            GetComponent<SpriteRenderer>().sprite = walkingFrames[currentFrameIndex];

            frameTimer += Time.deltaTime;
            if (frameTimer >= frameRate)
            {
                currentFrameIndex = (currentFrameIndex + 1) % walkingFrames.Length;
                frameTimer = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        float newDirectionX = -moveDirection.x;
        float newDirectionY = moveDirection.y;
        moveDirection = new Vector3(newDirectionX, newDirectionY, 0f).normalized;
    }
}
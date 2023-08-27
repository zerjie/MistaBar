using UnityEngine;

public class SortDraggableObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    public SortingController sortingController;
    private SpriteRenderer spriteRenderer;
    public Sprite[] fruitSprites;
    public Sprite[] beerSprites;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        sortingController = FindObjectOfType<SortingController>();
        if (this.CompareTag("RightObject1"))
            {
            spriteRenderer.sprite = beerSprites[Random.Range(0, beerSprites.Length)];
        }
        if (this.CompareTag("RightObject2"))
        {
            spriteRenderer.sprite = fruitSprites[Random.Range(0, fruitSprites.Length)];
        }

    }

    private void OnMouseDown()
    {
        // Calculate the offset between the click point and the object's center
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Get the new position based on the mouse position
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            // Keep the z-position unchanged for 2D objects
            newPosition.z = transform.position.z;
            // Update the object's position
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (this.CompareTag("RightObject1") && other.CompareTag("CorrectPosition1") && isDragging == false)
        {
            // Do something when the draggable object enters the trigger area
            sortingController.pointCount++;
            AudioEvents.currentAudio.WinSound();
            Destroy(gameObject);
            Debug.Log("Draggable object in correct area");
        }

        if (this.CompareTag("RightObject2") && other.CompareTag("CorrectPosition2") && isDragging == false)
        {
            // Do something when the draggable object enters the trigger area
            sortingController.pointCount++;
            AudioEvents.currentAudio.WinSound();
            Destroy(gameObject);
            Debug.Log("Draggable object in correct area");
        }
    }
}


using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

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
        if (other.CompareTag("CorrectPosition") && isDragging == false)
        {
            // Do something when the draggable object enters the trigger area
            Debug.Log("Draggable object in correct area");
        }
    }
}


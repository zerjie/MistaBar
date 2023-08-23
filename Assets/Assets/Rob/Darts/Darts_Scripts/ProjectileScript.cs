using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 10f; // Adjust the speed of the projectile

    private void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the projectile collided with the dartboard
        if (other.CompareTag("Dartboard"))
        {
            // Stick the projectile to the dartboard
            StickToDartboard(other.transform);
        }
    }

    private void StickToDartboard(Transform dartboardTransform)
    {
        // Attach the projectile to the dartboard
        transform.SetParent(dartboardTransform);

        // Disable the rigidbody to stop the projectile's movement
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}

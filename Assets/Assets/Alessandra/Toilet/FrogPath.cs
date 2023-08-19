using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FrogPath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] rightWaypoints;

    // Frogs
    [SerializeField]
    private GameObject rightFrog;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which frog goes to 
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {
        // Set position of Enemy as position of the first waypoint
        rightFrog.transform.position = rightWaypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        rightFrog.transform.position = Vector2.MoveTowards(rightFrog.transform.position,
            rightWaypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        Debug.Log("Here");

        if (transform.position == rightWaypoints[waypointIndex].transform.position)
        {
            waypointIndex++;

            Debug.Log("Here2");

        }

        if (waypointIndex == rightWaypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}

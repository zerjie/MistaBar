using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField] private Transform[] routes;

    public float speedMod;

    private int nextRoute;
    private float tParam;
    private Vector2 frogPos;
    
    public bool coroutineAllowed;

    void Start()
    {
        nextRoute = 0;
        tParam = 0;
        coroutineAllowed = true;
    }
    
    // Have Game Script declare couroutineAllowed = true in a method

    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByRoute(nextRoute));
        }
    }

    private IEnumerator GoByRoute(int routeNum)
    {
        // New coroutine won't start until previous is over
        coroutineAllowed = false;

        // Variables of all control points
        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedMod;

            // Bezier curve formula
            frogPos = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.position = frogPos;

            // return value for IEnumerator
            yield return new WaitForEndOfFrame();
        }

        // Next coroutine will start at 0
        tParam = 0f;

        // Frog will go to next curve if it exisy
        nextRoute += 1;

        if (nextRoute > routes.Length - 1)
        {
            nextRoute = 0;
        }

        // New one can be started
        coroutineAllowed = true;

        Debug.Log("Coroutine Done");
    }
}
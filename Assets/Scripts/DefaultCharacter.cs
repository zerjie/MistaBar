using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCharacter : MonoBehaviour
{
    public float lifetime = 1f;
    public float moveSpeed = 1f;

    public void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }

    public void ChangeColor(Color c)
    {
        GetComponent<Renderer>().material.color = c;
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}

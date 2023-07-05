using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject bulletPrefab;
    public int totalBullets = 5;
    public List<GameObject> bullets = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    private void Update()
    {
        foreach (GameObject bullet in bullets)
        {
            Vector3 pos = bullet.transform.position;
            pos.x += 0.005f;
            bullet.transform.position = pos;
        }
    }

    private IEnumerator SpawnBullet()
    {
        for (int i = 0; i < totalBullets; i++)
        {
            bullets.Add(Instantiate(bulletPrefab, spawnPosition));
            yield return new WaitForSeconds(5f);
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    private int AllofBulletsCount;


    void Start()
    {
        timeAfterSpawn = 0f;
        AllofBulletsCount = 0;
        target = FindObjectOfType<PlayerController>().transform;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject instance = Instantiate(bulletPrefabs, transform.position, transform.rotation);
            instance.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            ++AllofBulletsCount;
        }
    }

    public int getBulletCounts()
    {
        return AllofBulletsCount;
    }
}

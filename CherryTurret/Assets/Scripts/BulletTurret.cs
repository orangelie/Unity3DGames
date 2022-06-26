using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    public GameObject BulletInstance;
    public GameObject PlayerObj;

    public float bulletSpawnMin = 0.1f;
    public float bulletSpawnMax = 3f;

    private float bulletSpawn;
    private float lastFireTime;

    private CherryTurretAI ctAI;
    private PlayerController pController;

    void Start()
    {
        lastFireTime = 0;
        bulletSpawn = Random.Range(bulletSpawnMin, bulletSpawnMax);

        ctAI = GetComponent<CherryTurretAI>();
        pController = PlayerObj.GetComponent<PlayerController>();
    }


    void Update()
    {
        if (pController.GetIsDead() == 0) return;

        if (ctAI.GetisArounded())
        {
            lastFireTime += Time.deltaTime;
            if (lastFireTime >= bulletSpawn)
            {
                GameObject bullets = Instantiate(BulletInstance, transform.position, transform.rotation);
                bullets.transform.LookAt(PlayerObj.transform.position);

                lastFireTime = 0;
                bulletSpawn = Random.Range(bulletSpawnMin, bulletSpawnMax);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryTurretAI : MonoBehaviour
{
    public GameObject PlayerObj;
    public float TracingSpeed = 8f;

    private bool isArounded;
    private const float intersectDistance = 15f;

    void Start()
    {
        
    }

    void Update()
    {
        float dist = Vector3.Distance(PlayerObj.transform.position, transform.position);
        if (dist < intersectDistance)
        {
            Vector3 distanceVec3 = PlayerObj.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(distanceVec3), Time.deltaTime * TracingSpeed);
            isArounded = true;
        }
        else
        {
            isArounded = false;
        }
    }

    public bool GetisArounded()
    {
        return isArounded;
    }
}

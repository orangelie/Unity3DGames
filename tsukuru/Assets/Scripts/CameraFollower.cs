using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject target;
    public float followSpeed = 5f;

    private Vector3 targetPosition;

    void Start()
    {
        
    }

    void Update()
    {
        targetPosition.Set(target.transform.position.x, target.transform.position.y, transform.position.z);

        Vector3 currVelocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currVelocity, Time.deltaTime * followSpeed);
    }
}

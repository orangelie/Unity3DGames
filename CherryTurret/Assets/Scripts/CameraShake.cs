using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject camera;
    public float shakeAmount = 0.4f;
    public float shakeTime = 0.0f;

    private Vector3 initialPosition;

    private void Shake(float duration)
    {
        shakeTime = duration;
        initialPosition = camera.transform.localPosition;
    }

    void Start()
    {
        initialPosition = camera.transform.localPosition;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Shake(0.2f);
        }

        if(shakeTime > 0)
        {
            camera.transform.localPosition = initialPosition + Random.insideUnitSphere * shakeAmount;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0.0f;
            camera.transform.localPosition = initialPosition;
        }
    }
}

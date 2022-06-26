using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject PlayerObj;
    public Vector3 delta;
    public float WheelIntensity = 5f;

    private float mouseX = 0f;
    private float mouseY = 0f;
    private int isDead;

    void Start()
    {
        isDead = 1;
    }


    void Update()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * WheelIntensity;
        mouseY += Input.GetAxisRaw("Mouse Y") * WheelIntensity;
        mouseY = Mathf.Clamp(mouseY, -55f, 55f);

        transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0.0f) * isDead;

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.localEulerAngles), Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.localEulerAngles), Time.deltaTime);

        transform.position = PlayerObj.transform.position + delta;
    }
}

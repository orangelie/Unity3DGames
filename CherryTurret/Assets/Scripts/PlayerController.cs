using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject CameraObj;
    public float WheelIntensity = 5f;
    public float MoveSpeed = 10f;
    public float RunSpeed = 15f;

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

        float edittedMove = MoveSpeed;
        if (Input.GetKey(KeyCode.LeftControl))
            edittedMove += RunSpeed - MoveSpeed;

        float h = Input.GetAxis("Horizontal") * edittedMove * isDead;
        float v = Input.GetAxis("Vertical") * edittedMove * isDead;

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.localEulerAngles), Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.localEulerAngles), Time.deltaTime);
        rb.velocity = (transform.forward * v) + (transform.right * h);
    }

    public void Die()
    {
        isDead = 0;

        GameManager gManager = FindObjectOfType<GameManager>();
        if(gManager != null)
        {
            gManager.EndGame();
        }
    }

    public int GetIsDead()
    {
        return isDead;
    }
}

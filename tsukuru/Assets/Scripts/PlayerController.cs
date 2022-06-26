using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask layerMask;

    private Animator animator;
    private Vector3 velocity;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void AnimateKeyframe()
    {
        animator.SetBool("Walking", true);

        if (velocity.x != 0f)
        {
            animator.SetFloat("DirX", velocity.x);
            animator.SetFloat("DirY", 0f);
        }

        if (velocity.y != 0f)
        {
            animator.SetFloat("DirX", 0f);
            animator.SetFloat("DirY", velocity.y);
        }

        if (velocity.x == 0f && velocity.y == 0f)
        {
            animator.SetBool("Walking", false);
        }
    }

    private void MovePlayer()
    {
        float applyMoveSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            applyMoveSpeed += 5.0f;
        }


        velocity.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.transform.position.z);


        RaycastHit2D raycast;

        raycast = Physics2D.Raycast(transform.position, velocity.normalized, 0.5f, layerMask);
        Debug.DrawRay(transform.position, velocity.normalized * 0.5f, Color.yellow, 0.3f);

        if (raycast.transform != null)
        {
            return;
        }

        transform.Translate(velocity * applyMoveSpeed * Time.deltaTime);
    }

    void Update()
    {
        AnimateKeyframe();
        MovePlayer();
    }
}

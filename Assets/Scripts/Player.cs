using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed;

    private Rigidbody2D rigidbody;

    private float x;
    private float y;

    private Vector2 input;
    private bool moving;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetInput();
        Animate();
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = input * moveSpeed;
    }
    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }
    private void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving) 
        {
            animator.SetFloat("X", x); 
            animator.SetFloat("Y", y);
        }

        animator.SetBool("Moving", moving);
    }


}

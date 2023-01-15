using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rgbd2d.gravityScale= 0;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical"); 

        motionVector = new Vector2(horizontal,vertical);
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical",   vertical);

        moving = horizontal !=0 || vertical != 0;
        animator.SetBool("moving",moving);

        if(horizontal !=0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            animator.SetFloat("lastHorizontal", lastMotionVector.x);
            animator.SetFloat("lastVertical", lastMotionVector.y);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rgbd2d.velocity = motionVector * speed;
    }
}

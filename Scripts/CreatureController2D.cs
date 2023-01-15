using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CreatureController2D : MonoBehaviour
{
    // movement speed
    [SerializeField] float speed = 2f;

    // prevents errors when moving if no animations
    [SerializeField] bool hasAnimations = false;

    Rigidbody2D rigidbody2d;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (hasAnimations)
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // stupid move algo: compare position to target and move in it's direction
        Vector3 playerPosition = GameObject.Find("MainCharacter").transform.position;
        float horizontal = playerPosition.x - rigidbody2d.position.x;
        float vertical = playerPosition.y - rigidbody2d.position.y;

        motionVector = new Vector2(
            horizontal,
            vertical
            );

        if (hasAnimations)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);

            moving = horizontal != 0 || vertical != 0;
            animator.SetBool("moving", moving);
        }

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            if (hasAnimations)
            {
                animator.SetFloat("lastHorizontal", horizontal);
                animator.SetFloat("lastVertical", vertical);
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2d.velocity = motionVector * speed;
    }
}

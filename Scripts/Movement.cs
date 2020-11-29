using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1,10)]
    public float moveSpeed;
    
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        

        if(movement.x <= 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (movement.x >= 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(new Vector2(transform.position.x + movement.x * moveSpeed * Time.fixedDeltaTime, transform.position.y + movement.y * moveSpeed * Time.fixedDeltaTime));

    }
}

using System;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;

    Rigidbody2D rb;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        
    }

    // Update is called once per frame
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }



  
}

using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;

    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 5f;
    bool isGrounded = false;

    int maxJumps = 2;

    int jumpsLeft;

    Rigidbody2D rb;

    Animator animator;

    private Transform originalParent;

    private TextMeshPro username;

    MainMenu mainMenu;


    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        jumpsLeft = maxJumps;
        originalParent = transform.parent;
        mainMenu = FindAnyObjectByType<MainMenu>();
        
    }

    // Update is called once per frame
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (isGrounded && rb.velocity.y <= 0)
        {
            jumpsLeft = maxJumps;
        }
    

        if(Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpsLeft--;
            isGrounded=false;
            animator.SetBool("isJumping", !isGrounded);
            
        }

        if(Input.GetButtonDown("Pause"))
        {
            mainMenu.Pause();
        }

      
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }


    public void SetParent(Transform newParent)
    {
        originalParent= transform.parent;
        transform.parent = newParent;
    }

    public void ResetParent()
    {
        transform.parent = originalParent;
        Transform root = transform.root;
        DontDestroyOnLoad(root.gameObject);
    }


  
}

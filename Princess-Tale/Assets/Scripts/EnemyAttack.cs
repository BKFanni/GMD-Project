using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    private Transform playerPosition;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

        void Attack()
    {
            animator.SetBool("Running",false);
            animator.SetBool("Attack",true);
            FlipSprite();
    }

        void FlipSprite()
    {
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}

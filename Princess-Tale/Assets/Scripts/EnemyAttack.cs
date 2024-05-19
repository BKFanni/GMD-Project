using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Transform player;
    private Transform playerPosition;
    public float damagePerAttack = 0.25f;
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;
    public Animator animator;
    private PlayerHealth playerHealth;
    void Awake()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        playerPosition = player;
    }
    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth script not found. Make sure it's attached to the player GameObject.");
        }
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackCooldown;
        }
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerAttack);
            playerHealth.UpdateHealthUI();
        }
        animator.SetBool("Running", false);
        animator.SetBool("Attack", true);
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

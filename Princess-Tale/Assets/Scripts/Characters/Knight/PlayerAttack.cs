using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRate = 1f;
    public string enemyTag = "Enemy";
    public string dragonTag = "Dragon";
    public float attackRange = 1f;
    public int attackDamage = 15;
    public AudioSource audioSource;
    private Animator animator;
    private Transform playerPosition;
    private float nextAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPosition = transform;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("Attack", true);
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else
            {
           
                animator.SetBool("Attack", false);
            }
        }
    }

   

    void Attack()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        Collider2D[] enemies = Physics2D.OverlapCircleAll(playerPosition.position, attackRange);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag(enemyTag))
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
            else if (enemy.CompareTag(dragonTag))
            {
                EnemyHealth dragonHealth = enemy.GetComponent<EnemyHealth>();
                if (dragonHealth != null)
                {
                    dragonHealth.TakeDamage(attackDamage);
                }
            }
        }
    }


}

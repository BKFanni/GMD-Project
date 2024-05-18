using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRate = 1f;
    public string enemyTag = "Enemy";
    public float attackRange = 1f;
    public int attackDamage = 10;
    private Animator animator;
    private Transform playerPosition;
    private float nextAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPosition = transform;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        animator.SetBool("Attack", Input.GetKey(KeyCode.Return));
    }

    void Attack()
    {
        // Play attack animation
        animator.SetBool("Attack", true);

        // Detect enemies within range
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
        }
    }

    void OnDrawGizmosSelected()
    {
        if (playerPosition == null)
            playerPosition = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerPosition.position, attackRange);
    }
}

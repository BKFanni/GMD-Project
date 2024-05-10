using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRate = 1f;
    public string enemyTag = "Enemy";
    public float attackRange = 2f;
    public int attackDamage = 10; // Adjust the damage as needed

    private Animator animator;
    private Transform playerPosition;
    private float nextAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPosition = transform; // Player's position
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Change to desired key for attack
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(playerPosition.position, attackRange);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy != null && enemy.CompareTag(enemyTag))
            {
                animator.SetBool("Attack", true);
                // Add attack logic here
                //  EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                // if (enemyHealth != null)
                // {
                //   enemyHealth.TakeDamage(attackDamage);
                // }
            }
        }

        nextAttackTime = Time.time + 1f / attackRate;
    }
}

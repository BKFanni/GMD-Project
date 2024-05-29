using System.Net.Cache;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Animator animator;
    private bool isDead = false;

    [SerializeField] FloatingHealthBar healthBar;

    void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;
            healthBar.UpdateHealthBar(currentHealth,maxHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("Die", true);
        Invoke("DestroyEnemy", 0.8f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

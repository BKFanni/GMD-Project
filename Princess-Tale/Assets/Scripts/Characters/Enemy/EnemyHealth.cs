using System.Net.Cache;
using UnityEngine;
using System.Collections;

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
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
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
        StartCoroutine(CheckDeathAnimationComplete());
    }

    IEnumerator CheckDeathAnimationComplete()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            Debug.Log("Waiting for Die animation to start...");
            yield return null;
        }

        Debug.Log("Die animation started.");
        
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            Debug.Log("Die animation playing...");
            yield return null;
        }

        Debug.Log("Die animation completed.");

        Destroy(gameObject);
    }
}

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxLives = 3;
    public float maxHealthPerLife = 100f;
    public float currentHealth;
    public int currentLives;
    private Health healthScript;
    public Animator animator;

    void Start()
    {
        healthScript = GetComponent<Health>();
        animator = GetComponent<Animator>();
        currentLives = maxLives;
        currentHealth = maxHealthPerLife;
        if (healthScript != null)
        {
            UpdateHealthUI();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentLives--;
            if (currentLives > 0)
            {
                currentHealth = maxHealthPerLife;
            }
            else
            {
                Die();
                return;
            }
        }

        UpdateHealthUI();
    }

    void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("isDead");
        }
    }

    public void UpdateHealthUI()
    {
        if (healthScript != null)
        {
            healthScript.health = currentHealth;
            healthScript.numOfHearts = currentLives;
        }
    }
}

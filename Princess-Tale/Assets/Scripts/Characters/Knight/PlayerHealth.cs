using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public float maxHealthPerLife = 1; // Each heart represents 1 unit of health
    public float currentHealth;
    public int currentLives;
    private Health healthScript;
    public GameObject canvas;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        canvas.SetActive(false);
        animator.ResetTrigger("isDead");
        healthScript = GetComponent<Health>();
        currentLives = maxLives;
        currentHealth = maxHealthPerLife; // Starting health is full
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
                currentHealth = maxHealthPerLife * currentLives;
            }
            else
            {
                currentHealth = 0; // Ensure current health doesn't go negative
                Die();
            }
        }
        UpdateHealthUI();
    }

    public void GainHealth(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealthPerLife * maxLives)
        {
            currentHealth = maxHealthPerLife * maxLives;
        }
        UpdateHealthUI();
    }

    void Die()
    {
        if (canvas != null)
        {
            animator.SetTrigger("isDead");
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UpdateHealthUI()
    {
        if (healthScript != null)
        {
            healthScript.health = currentHealth;
        }
    }

}

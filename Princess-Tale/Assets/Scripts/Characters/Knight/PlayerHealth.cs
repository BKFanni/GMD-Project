using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxLives = 3;
    public float maxHealthPerLife = 100f;
    public float currentHealth;
    public int currentLives;
    private Health healthScript;
    public GameObject canvas;
    private bool gameIsOver = false;

    void Start()
    {
        healthScript = GetComponent<Health>();
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
        if (canvas != null)
        {
            canvas.SetActive(true);
        }

        Time.timeScale = 0;
        gameIsOver = true;

    }

    public void UpdateHealthUI()
    {
        if (healthScript != null)
        {
            healthScript.health = currentHealth;
            healthScript.numOfHearts = currentLives;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GameOver") && !gameIsOver)
        {
            Die();
        }
    }
}

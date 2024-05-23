using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject, 0.8f);
    }
}

using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float fallThreshold = 7f; 
    public float damageMultiplier = 0.1f; 
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private float lastYPosition;
    private bool isFalling = false;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        lastYPosition = transform.position.y;
    }

    void Update()
    {
        float currentYPosition = transform.position.y;

        if (rb.velocity.y < 0) // Player is falling
        {
            if (!isFalling)
            {
                lastYPosition = currentYPosition;
                isFalling = true;
            }
        }
        else if (isFalling && rb.velocity.y == 0) // Player landed
        {
            float fallDistance = lastYPosition - currentYPosition;
            if (fallDistance > fallThreshold)
            {
                float effectiveFallDistance = fallDistance - fallThreshold;
                float damage = effectiveFallDistance * damageMultiplier;
                playerHealth.TakeDamage(damage);
                Debug.Log($"Player fell {fallDistance} units and took {damage} damage.");
            }
            isFalling = false;
            lastYPosition = currentYPosition; // Reset lastYPosition after landing
        }
    }
}

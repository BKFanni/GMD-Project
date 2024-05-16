using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public float healthBonus = 0.5f;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.GainHealth(healthBonus);
            }
        }
    }
}

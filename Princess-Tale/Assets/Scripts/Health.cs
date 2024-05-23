using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite _3quarterHeart;
    public Sprite halfHeart;
    public Sprite _1quarterHeart;
    public Sprite emptyHeart;

    PlayerHealth playerHealth;
    void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    void Update()
    {
        float remainingHealth = playerHealth.currentHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            // Calculate the health value for the current heart
            float heartHealth = Mathf.Max(remainingHealth, 0);
            remainingHealth -= 1;

            // Set the sprite for the current heart based on its health value
            if (heartHealth >= 1)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (heartHealth >= 0.75f)
            {
                hearts[i].sprite = _3quarterHeart;
            }
            else if (heartHealth >= 0.5f)
            {
                hearts[i].sprite = halfHeart;
            }
            else if (heartHealth >= 0.25f)
            {
                hearts[i].sprite = _1quarterHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}

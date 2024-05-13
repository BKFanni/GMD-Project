using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Sprite _3quarterHeart;
    public Sprite _1querterHeart;

    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            float heartValue = (float)health - i;
            if (heartValue >= 1f)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (heartValue >= 0.75f)
            {
                hearts[i].sprite = _3quarterHeart;
            }
            else if (heartValue >= 0.5f)
            {
                hearts[i].sprite = halfHeart;
            }
            else if (heartValue >= 0.25f)
            {
                hearts[i].sprite = _1querterHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}

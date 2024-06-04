using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOutOfWorld : MonoBehaviour
{
    public GameObject canvas;
    Animator animator;
    public bool endOfGame;

    PlayerHealth playerHealth;

   

    
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        canvas.SetActive(false);
        animator.ResetTrigger("isDead");
        endOfGame = false;
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GameOver")
        {
            animator.SetTrigger("isDead");
            playerHealth.currentHealth = 0;
            canvas.SetActive(true);
            endOfGame = true;
            Time.timeScale = 0; //pause game
 
        }
    }

    
}

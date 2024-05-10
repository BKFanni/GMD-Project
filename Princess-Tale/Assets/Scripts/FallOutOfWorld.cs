using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOutOfWorld : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject canvas;
    Animator animator;
    public bool endOfGame;

   

    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canvas.SetActive(false);
        animator.ResetTrigger("isDead");
        endOfGame = false;
        
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
            canvas.SetActive(true);
            endOfGame = true;
            Time.timeScale = 0; //pause game
 
        }
    }

    
}

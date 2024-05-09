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

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canvas.SetActive(false);
        animator.ResetTrigger("isDead");

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
            Time.timeScale = 0; //pause game
        }
    }

    
}

using UnityEngine;
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;
    public float idleTime = 1f;

    private Transform currentTarget;
    private Animator animator;

    void Start()
    {
        currentTarget = pointA;
        animator = GetComponent<Animator>();
        StartCoroutine(MoveBetweenPoints());
    }

    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            animator.SetBool("Running",false);
            animator.SetBool("Attack",false);
            float diffA = Math.Abs(transform.position.x - pointA.position.x);
            float diffB = Math.Abs(transform.position.x - pointB.position.x);
            while (Vector2.Distance(transform.position, currentTarget.position) > 0.1f && animator.GetBool("Attack")==false)
            {
                animator.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
                 if(diffA < diffB) 
                    {
                        transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                    }
                else if(diffA > diffB) 
                    {
                        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    }
                yield return null;
            }


            animator.SetBool("isMoving", false);
            yield return new WaitForSeconds(idleTime);


            currentTarget = (currentTarget == pointA) ? pointB : pointA;

 
            if(diffA < diffB) 
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            else if(diffA > diffB) 
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            }
        }
    }
}
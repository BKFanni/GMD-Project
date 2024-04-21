using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected int moveSpeed;

    private Vector3 _currentTarget;
    private Animator animator;



    void Start()
    {
        _currentTarget = pointA.position;
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        MoveBetweenPoints();
    }

    void MoveBetweenPoints()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;

            animator.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            animator.SetTrigger("Idle");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, moveSpeed * Time.deltaTime);
            animator.SetTrigger("Walk");
        }
        FlipSprite();
    }
    void FlipSprite()
    {
        if (_currentTarget == pointA.position)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

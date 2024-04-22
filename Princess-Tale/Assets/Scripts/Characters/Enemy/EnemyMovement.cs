using UnityEngine;
using System.Collections;

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

            while (Vector2.Distance(transform.position, currentTarget.position) > 0.1f)
            {
                animator.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
                yield return null;
            }


            animator.SetBool("isMoving", false);
            yield return new WaitForSeconds(idleTime);


            currentTarget = (currentTarget == pointA) ? pointB : pointA;


            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 3f;
    public float idleTime = 2f;
    public bool isPatrolling = true;

    private int currentPatrolIndex = 0;
    private bool isIdling = false;
    void Start()
    {
        StartCoroutine(Patrol());
    }

    void Update()
    {

        if (!isIdling && isPatrolling)
        {
            MoveTowardsPatrolPoint();
        }
    }

    void MoveTowardsPatrolPoint()
    {
        Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            StartCoroutine(Idle());
        }
    }

    IEnumerator Idle()
    {
        isIdling = true;
        yield return new WaitForSeconds(idleTime);

        isIdling = false;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (!isIdling)
            {
                MoveTowardsPatrolPoint();
            }

            yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Transform playerPosition;
    [SerializeField] float targetpos;
    private Vector2 currentPos;
    public float distance;
    public float speed;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        FollowTarget();
    }


    void FollowTarget()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) < distance && Vector2.Distance(transform.position, playerPosition.position) > targetpos)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
            animator.SetBool("Running", true);
        }
        else
        {
            if (Vector2.Distance(transform.position, currentPos) <= 1)
            {
                animator.SetBool("Running", false);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
                animator.SetBool("Running", true);
            }
        }
        FlipSprite();
    }

    void FlipSprite()
    {
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
    }

    void Attack()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) < targetpos)
        {
            animator.SetBool("Running",false);
            animator.SetBool("Attack",true);
        }
        else
        {
            animator.SetBool("Attack",false);
        }
    }
}
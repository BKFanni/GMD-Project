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
        FollowTarget();
    }


    void FollowTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        animator.SetBool("Running", true);
        animator.SetBool("Attack",false);
        FlipSprite();
    }

    void FlipSprite()
    {
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }


}
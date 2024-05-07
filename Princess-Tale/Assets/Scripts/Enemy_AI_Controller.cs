using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Controller : MonoBehaviour
{
    public Transform player;
    private Transform playerPosition;
    public float distance;
    [SerializeField] float targetpos;
    private FollowPlayer followPlayer;
    private  EnemyMovement enemyMovement;
    private  EnemyAttack enemyAttack;
    private Return enemyReturn;
    public Transform pointA;
    public Transform pointB;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = GetComponent<FollowPlayer>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyReturn = GetComponent<Return>();
        playerPosition = player.GetComponent<Transform>();
        enemyAttack = GetComponent<EnemyAttack>();
        pointA = GetComponent<Transform>();
        pointB = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlEnemy();
    }

    void ControlEnemy()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) <= distance && Vector2.Distance(transform.position, playerPosition.position) > 2)
        {
            enemyAttack.enabled = false;
            enemyReturn.enabled = false;
            enemyMovement.enabled = false;
            followPlayer.enabled = true;
            
        }
        else if (Vector2.Distance(transform.position, playerPosition.position) >= 0.1f && Vector2.Distance(transform.position, playerPosition.position) <= 2)
        {
            followPlayer.enabled = false;
            enemyReturn.enabled=false;
            enemyMovement.enabled = false;
            enemyAttack.enabled = true;
            
        }
        else if (transform.position.x >= pointA.position.x && transform.position.x <= pointB.position.x) 
        {
            enemyAttack.enabled = false;
            enemyReturn.enabled=true;
            followPlayer.enabled = false;
            enemyMovement.enabled = true;
          
        }
        else
        {
            enemyAttack.enabled = false;
            followPlayer.enabled = false;
            enemyMovement.enabled =false;
            enemyReturn.enabled=true;
        }
    }
}

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

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = GetComponent<FollowPlayer>();
        enemyMovement = GetComponent<EnemyMovement>();
        playerPosition = player.GetComponent<Transform>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlEnemy();
    }

    void ControlEnemy()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) < distance && Vector2.Distance(transform.position, playerPosition.position) > 2)
        {
            enemyAttack.enabled = false;
            enemyMovement.enabled = false;
            followPlayer.enabled = true;
            
        }
        else if (Vector2.Distance(transform.position, playerPosition.position) >= 0.1f && Vector2.Distance(transform.position, playerPosition.position) <= 2)
        {
            followPlayer.enabled = false;
            enemyMovement.enabled = false;
            enemyAttack.enabled = true;
            
        }
        else
        {
            enemyAttack.enabled = false;
            followPlayer.enabled = false;
            enemyMovement.enabled = true;
          
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;


    private Transform targetWayPoint;

    private int currentWayPointIndex = 0;

    void Start(){

        targetWayPoint = waypoints[0];
      
    }

    void Update(){
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetWayPoint.position,
            speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,targetWayPoint.position) < checkDistance)
        {
            targetWayPoint = GetNextWayPoint();
        }
    }

    private Transform GetNextWayPoint(){
        currentWayPointIndex++;
        if(currentWayPointIndex >= waypoints.Length)
        {
            currentWayPointIndex = 0;
        }

        return waypoints[currentWayPointIndex];
    }

      private void OnCollisionEnter2D(Collision2D other)
    {
        var playerMovement = other.collider.GetComponent<PlayerMovement>();
        if(playerMovement != null)
        {
            playerMovement.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var playerMovement = other.collider.GetComponent<PlayerMovement>();
        if(playerMovement != null)
        {
            playerMovement.ResetParent();
        }
    }

   
    
}

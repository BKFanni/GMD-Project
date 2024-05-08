using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Return : MonoBehaviour
{
    public float speed;
    public Transform pointA;
    public Transform pointB;
    // Start is called before the first frame update
    void Start()
    {
        pointA = GetComponent<Transform>();
        pointB = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ReturnToPosition();
    }

    void ReturnToPosition()
    {
        float diffA = Math.Abs(transform.position.x - pointA.position.x);
        float diffB = Math.Abs(transform.position.x - pointB.position.x);
            if(diffA < diffB) 
            {
                transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            else if(diffA > diffB) 
            {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            }
    
        }
}

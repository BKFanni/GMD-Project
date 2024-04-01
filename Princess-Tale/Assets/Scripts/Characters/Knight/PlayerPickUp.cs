using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public pickUp pickUp;
    // Start is called before the first frame update
    void Start()
    {
        pickUp = FindObjectOfType<pickUp>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PickUp"))
        {
            Destroy(collider.gameObject);
            pickUp.count++;
        }
    }
}

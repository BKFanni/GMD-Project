using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public AudioClip pickupSound;
    private AudioSource audioSource;
    public pickUp pickUp;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        pickUp = FindObjectOfType<pickUp>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PickUp"))
        {
            audioSource.PlayOneShot(pickupSound);
            Destroy(collider.gameObject);
            //  pickUp.count++;
        }
    }
}

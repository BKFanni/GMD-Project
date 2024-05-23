using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 0.25f;

    private Transform player;
    private Vector3 direction;

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        if (player != null)
        {
            direction = (player.position - transform.position).normalized;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class shooting : MonoBehaviour
{
    public float Speed;
    public float damagePerAttack = 0.25f;

    private void Update()
    {
        Vector3 shootingDirection = transform.right;
        transform.Translate(shootingDirection * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerAttack);
            }
        }

        if (collision.GetComponent<shootingAction>())
        {
            collision.GetComponent<shootingAction>().Action();
        }

        Destroy(gameObject);
    }
}

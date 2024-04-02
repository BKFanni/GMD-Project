
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float Speed;
    private void Update()
    {
        Vector3 shootingDirection = transform.right;

        transform.Translate(shootingDirection * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<shootingAction>())
            collision.GetComponent<shootingAction>().Action();
        Destroy(gameObject);


    }

}

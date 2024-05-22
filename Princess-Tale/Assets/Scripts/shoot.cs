using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ShootingItem;
    public Transform ShootingPoint;
    public float shootingRange = 10f;
    public float shootingCooldown = 2f;

    private Transform player;
    private bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure to assign the player.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= shootingRange && canShoot)
            {
                Shooting();
            }
        }
    }

    void Shooting()
    {
        GameObject si = Instantiate(ShootingItem, ShootingPoint.position, ShootingPoint.rotation);
        si.transform.parent = null;

        StartCoroutine(ShootingCooldown());
    }

    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingCooldown);
        canShoot = true;
    }
}

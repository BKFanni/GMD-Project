using System.Collections;
using UnityEngine;

public class DragonFireball : MonoBehaviour
{
    public GameObject fireball;
    public Transform firePosition;
    public float firingRange = 10f;
    public float firingCooldown = 2f;

    private Transform player;
    private bool canFire = true;

    private void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player != null && IsPlayerInRange() && canFire)
        {
            Fire();
        }
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= firingRange;
    }

    private void Fire()
    {
        GameObject fireballInstance = Instantiate(fireball, firePosition.position, firePosition.rotation);
        fireballInstance.transform.parent = null;

        StartCoroutine(FireCooldown());
    }

    private IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(firingCooldown);
        canFire = true;
    }
}

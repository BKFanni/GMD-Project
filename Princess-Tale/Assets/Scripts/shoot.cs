using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject ShootingItem;
    public Transform ShootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if (!canShoot)
            return;
        GameObject si = Instantiate(ShootingItem, ShootingPoint);
        si.transform.parent = null;
    }
}

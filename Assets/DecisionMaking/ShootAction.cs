using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootRate;

    public void Shoot()
    {
        var bulletGo = Instantiate(bulletPrefab);
        bulletGo.transform.position = transform.position;
        bulletGo.transform.rotation = transform.rotation;

        bulletGo.GetComponent<Bullet>().SetTeam(GetComponent<HealthState>().team);
    }

    internal void StartShooting()
    {
        InvokeRepeating("Shoot", shootRate, shootRate);
    }

    internal void StopShooting()
    {
        CancelInvoke("Shoot");
    }
}

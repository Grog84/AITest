using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void Shoot()
    {
        var bulletGo = Instantiate(bulletPrefab);
        bulletGo.transform.position = transform.position;
        bulletGo.transform.rotation = transform.rotation;

        bulletGo.GetComponent<Bullet>().SetTeam(GetComponent<HealthState>().team);
    }
	
}

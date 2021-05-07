using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles;

    [SerializeField]
    private Transform[] projectilesSpawnPoints;

    [SerializeField]
    private float shootHold = 0.2f;

    private float shootTimer;

    private bool canShoot;

    private void Update()
    {
        if (Time.time > shootTimer)
            canShoot = true; 

        HandlePlayerShooting();
    }


    void HandlePlayerShooting()
    {
        //if we wan't shoot 
        if (!canShoot)
            return;

        // shoot blaster 1
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(projectiles[0],projectilesSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[0], projectilesSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // shoot blaster 2
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(projectiles[1], projectilesSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[1], projectilesSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // Laser Shoot
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(projectiles[2], projectilesSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[2], projectilesSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // Heavy Rocket
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(projectiles[3], projectilesSpawnPoints[2].position, Quaternion.identity);

           

            ResetShootingTimer();
        }
        // Misile
        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(projectiles[4], projectilesSpawnPoints[2].position, Quaternion.identity);

           

            ResetShootingTimer();
        }

    }
    //handle shooting
    void ResetShootingTimer()
    {
        canShoot = false;
        shootTimer = Time.time + shootHold;
    }

}// class














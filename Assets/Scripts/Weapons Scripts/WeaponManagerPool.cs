using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

   [SerializeField]
    private List<GameObject> projectilePool = new List<GameObject>();

    
    private GameObject projectileHolder;

    [SerializeField]
    private KeyCode keyToPressToShoot;

    private bool projectileSpawned;

    [SerializeField]
    private Transform projectileSpawnPoint;

    [SerializeField]
    private float shootWaitTime = 0.2f;

    private float shootTimer;

    private bool canShoot;

    [SerializeField]
    private bool isEnemy;



    private void Awake()
    {
        if (isEnemy)
        {
            projectileHolder = GameObject.FindWithTag(TagMnager.ENEMY_PROJECTILE_HOLDER_TAG);
            ResetShootingTimer();
        }
        else
            projectileHolder = GameObject.FindWithTag(TagMnager.PLAYER_PROJECTILE_HOLDER_TAG); 
    }

    private void Update()
    {
        if (Time.time > shootTimer)
            canShoot = true;

        HandlePlayerShooting();
        HandleEnemyShooting();
    }
    void HandlePlayerShooting()
    {
        if (!canShoot || isEnemy)
            return;

        if (Input.GetKeyDown(keyToPressToShoot))
        {
            GetObjectFromPoolOrSpawnANewOne();
            ResetShootingTimer();
            
        }
    }

    void GetObjectFromPoolOrSpawnANewOne()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = projectileSpawnPoint.position;
                projectilePool[i].SetActive(true);

                projectileSpawned = true;

                break;
            }
            else
            {
                projectileSpawned = false;
               ;
            }
        }

        if (!projectileSpawned)
        {
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);

            projectilePool.Add(newProjectile);

            newProjectile.transform.SetParent(projectileHolder.transform);
            projectileSpawned = true;


        }
    }
    private void ResetShootingTimer()
    {
        canShoot = false;
        
        // Same player and Enemy projectiles shoots randomly 
        if(isEnemy)
             shootTimer = Time.time + Random.Range(shootWaitTime, (shootWaitTime +1f));
        else
             shootTimer = Time.time + shootWaitTime;


        // Set time which both projectiles could shoot at once .
        //shootTimer = Time.time + shootWaitTime;
    }   

    void HandleEnemyShooting()
    {
        if (!isEnemy || !canShoot)
            return;

        ResetShootingTimer();
        GetObjectFromPoolOrSpawnANewOne();
    }


}

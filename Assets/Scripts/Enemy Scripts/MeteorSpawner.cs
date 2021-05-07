using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteors;

    [SerializeField]
    private float minX, maxX;

    [SerializeField]
    private float minSpwanInterval = 4f, maxSpawnInterval = 5f;

    [SerializeField]
    private int minSpawnedNumber = 1, maxSpawnedNumber = 2;

    private int ranSpawnNum;

    private Vector3 randSpawnPos;



    private void Start()
    {
        //InvokeRepeating("SpawnMeteors", 5f, 1f);

        Invoke("SpawnMeteors", Random.Range(minSpwanInterval, maxSpawnInterval));
    }
    void SpawnMeteors()
    {
        ranSpawnNum = Random.Range(minSpawnedNumber, maxSpawnedNumber);
        for (int i = 0; i < ranSpawnNum; i++)
        {
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);

        }
        Invoke("SpawnMeteors", Random.Range(minSpwanInterval, maxSpawnInterval));
    }

   
} //class













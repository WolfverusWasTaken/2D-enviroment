using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] SpawnPoints;
    public static int totalspawns;

    [Range(1, 50)]
    public int SpawnLimiter;


    // Start is called before the first frame update
    void Start()
    {
        totalspawns = 0;
        SpawnLimiter = 15;


    }

    // Update is called once per frame
    void Update()
    {
        if (totalspawns < SpawnLimiter)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawn = Random.Range(0, SpawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], SpawnPoints[randSpawn].position, transform.rotation);
            totalspawns = totalspawns + 1;
            ScreenBounder.inmapspawns = totalspawns;
        }
        
    }
}

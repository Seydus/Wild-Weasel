using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance;
    public static GameControlScript Instance { get { return instance; } }

    //public GameObject[] enemies;
    public Transform[] spawnPoint;
    public Transform[] fastSpawnPoint;

    public float backToStartFastSpawn;
    private float startFastSpawn;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    ObjectPooler objectpool;

    public bool enemySpawner = true;

    private void Start()
    {
        objectpool = ObjectPooler.instance;

        timeBtwSpawns = startTimeBtwSpawns;
        startFastSpawn = backToStartFastSpawn;
    }

    private void Update()
    {
        if (enemySpawner == true)
        {
            //For normal missiles
            if (timeBtwSpawns <= 0)
            {
                //rand = Random.Range(0, enemies.Length);
                int randPosition = Random.Range(0, spawnPoint.Length);

                objectpool.SpawnFromPool("Missiles", spawnPoint[randPosition].transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }

            ////For fast missiles
            //if(startFastSpawn <= 0)
            //{
            //    int randFastPosition = Random.Range(0, spawnPoint.Length);

            //    objectpool.SpawnFromPool("FastMissiles", spawnPoint[randFastPosition].transform.position, Quaternion.identity);
            //    startFastSpawn = backToStartFastSpawn;
            //}
            //else
            //{
            //    startFastSpawn -= Time.deltaTime;
            //}
        }
    }
}

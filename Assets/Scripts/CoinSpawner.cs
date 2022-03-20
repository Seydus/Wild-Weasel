using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner instance;
    public static CoinSpawner Instance { get { return instance; } }

    public GameObject coins;

    public int numberOfCoinToSpawn;
    public float nextCoinSpawn;
    public int chanceCoinToSpawn;

    public bool allowedToSpawn = true;

    ObjectPooler objectPool;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectPool = ObjectPooler.instance;
        nextCoinSpawn = Random.Range(1, 2);
    }

    private void Update()
    {
        if (allowedToSpawn)
        {
            nextCoinSpawn -= Time.deltaTime;

            if (nextCoinSpawn <= 0)
            {
                for (int i = 0; i < numberOfCoinToSpawn; i++)
                {
                    float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                    float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                    Vector2 spawnPosition = new Vector2(spawnX, spawnY);

                    objectPool.SpawnFromPool("Coins", spawnPosition, Quaternion.identity);
                }

                nextCoinSpawn = Random.Range(2, chanceCoinToSpawn);
            }
        }
    }
}

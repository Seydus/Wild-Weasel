using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldSpawner : MonoBehaviour
{
    public static ShieldSpawner instance;

    [Header("Shield Spawner")]
    public GameObject shield;
    public GameObject shieldActivate;

    public float shieldCount;
    public float spawnTime;

    public bool allowedToSpawn = true;

    //
    [Header("Shield Slider")]
    public Image shieldBarImage;

    public float shieldBarValue = 1f;

    public bool airplaneShield = false;

    ObjectPooler objectPool;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        objectPool = ObjectPooler.instance;

        shieldBarImage.fillAmount = shieldBarValue;
        spawnTime = Random.Range(10, 15);
    }

    private void Update()
    {
        if (airplaneShield == true)
        {
            shieldActivate.SetActive(true);
        }

        if (allowedToSpawn)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                for (int i = 0; i < shieldCount; i++)
                {
                    float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                    float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

                    Vector2 spawnPosition = new Vector2(spawnX, spawnY);

                    objectPool.SpawnFromPool("Shields", spawnPosition, Quaternion.identity);
                }

                spawnTime = Random.Range(7, 15);
            }
        }

        //
        if (airplaneShield)
        {
            shieldBarImage.fillAmount -= 0.003f;
        }

        if (shieldBarImage.fillAmount <= 0)
        {
            allowedToSpawn = true;
            shieldActivate.SetActive(false);
            shieldBarImage.fillAmount = shieldBarValue;
            airplaneShield = false;
        }
    }
}

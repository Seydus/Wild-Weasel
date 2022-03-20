using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldObject : MonoBehaviour
{
    public float shieldAdded;
    float shieldWillDespawn;

    private void Start()
    {
        shieldWillDespawn = 10;
    }

    private void Update()
    {
        if (ShieldSpawner.instance.allowedToSpawn)
        {
            shieldWillDespawn -= Time.deltaTime;

            if (shieldWillDespawn <= 0)
            {
                shieldWillDespawn = shieldAdded;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShieldSpawner.instance.allowedToSpawn = false;
            ShieldSpawner.instance.airplaneShield = true;
            ShieldSpawner.instance.shieldBarImage.fillAmount = 1f;
            Destroy(gameObject);
        }
    }
}

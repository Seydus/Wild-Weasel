using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsObject : MonoBehaviour
{

    public float coinsWillDie = 15f;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coinsWillDie = 15f;
    }

    private void Update()
    {
        if (CoinSpawner.instance.allowedToSpawn)
        {
            coinsWillDie -= Time.deltaTime;

            if (coinsWillDie <= 5)
            {
                anim.SetTrigger("coinFade");
            }

            if (coinsWillDie <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Sfx.PlaySound("coinSound");
            GameManager.Instance.currency += 1;
            PlayerPrefs.SetInt("Currency", GameManager.Instance.currency);

            gameObject.SetActive(false);
        }
    }
}

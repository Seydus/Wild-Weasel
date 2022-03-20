using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float accelerationSpeed;
    public float maximumSpeed;
    public float minSpeed;
    public float rotatingSpeed = 200;

    public float deathCount = 20f;

    public ScoreUI score;
    public GameObject explosion;
    GameObject player;
    Rigidbody2D myBody;

    ObjectPooler objectPool;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        objectPool = ObjectPooler.instance;
    }

    void Update()
    {
        //Faces the player
        Vector2 point2Target = (Vector2)transform.position - (Vector2)player.transform.position;
        point2Target.Normalize();

        float value = Vector3.Cross(point2Target, transform.right).z;

        /*
        if (value > 0) {

                rb.angularVelocity = rotatingSpeed;
        } else if (value < 0)
                rb.angularVelocity = -rotatingSpeed;
        else
                rotatingSpeed = 0;
*/

        myBody.angularVelocity = rotatingSpeed * value;
        myBody.velocity = transform.right * minSpeed;


        //Increase Speed Gradually.

        minSpeed += accelerationSpeed;

        if (minSpeed > maximumSpeed)
        {
            minSpeed = maximumSpeed;
        }

        deathCount -= Time.deltaTime;

        if(deathCount <= 5)
        {
            anim.SetBool("isDead", true);
        }

        if(deathCount <= 0)
        {
            anim.SetBool("isDead", false);
            gameObject.SetActive(false);
            Sfx.PlaySound("explosiondSoundEnemy");
            Instantiate(explosion, transform.position, Quaternion.identity);
            explosion.GetComponent<SpriteRenderer>().enabled = true;
            deathCount = 15;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            //when the enemy collides with the same tag then they both explode.
            Sfx.PlaySound("explosiondSoundEnemy");
            Instantiate(explosion, transform.position, Quaternion.identity);
            explosion.GetComponent<SpriteRenderer>().enabled = true;

            gameObject.SetActive(false);

            GameManager.Instance.currency += 1;
            PlayerPrefs.SetInt("Currency", GameManager.Instance.currency);
        }

        if(other.tag == "Player")
        {
            Sfx.PlaySound("explosiondSoundEnemy");
            Instantiate(explosion, transform.position, Quaternion.identity);
            explosion.GetComponent<SpriteRenderer>().enabled = true;

            gameObject.SetActive(false);
        }
    }
}



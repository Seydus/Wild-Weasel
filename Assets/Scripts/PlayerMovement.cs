using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float moveSpeed;
    Rigidbody2D myBody;
    protected Joystick joystick;

    public float turnSpeed = 5;
    float joypos;

    Animator anim;
    public int numberAnimChange;

    // Minimum amount of joystick deflection that should count to change direction.
    public float joystickThreshold = 0.1f;

    // Let's save a vector for our current direction of travel.
    // (Initialize this to your default movement direction if you don't want to spawn at rest)
    Vector2 moveDirection;
    Vector2 stick;

    public GameUI ui;
    public ScoreUI score;

    [HideInInspector]
    public GameObject joyStickObj;
    public GameObject[] trails;
    GameObject explosionSfx;
    public GameObject explosion;
    public GameObject enemySpawner;
    GameObject backgroundMusic;
    public GameObject isInGameMenuObj;
    public GameObject adToResurrect;
    public GameObject resurrectButton;
    public GameObject player;

    public bool resurrected = false;

    float trailPositionXRight;
    float trailPositionXLeft;
    float trailPositionY;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        moveSpeed = PlayerPrefs.GetFloat("planeMoveSpeed", 5);

        trailPositionXRight = PlayerPrefs.GetFloat("trailPositionXRight", 0.3f);
        trailPositionXLeft = PlayerPrefs.GetFloat("trailPositionXLeft", -0.3f);
        trailPositionY = PlayerPrefs.GetFloat("trailPositionY", -0.04f);

        numberAnimChange = PlayerPrefs.GetInt("planeAnimNumber", 1);

        trails[0].transform.position = new Vector2(player.transform.position.x + trailPositionXRight, player.transform.position.y + trailPositionY);
        trails[1].transform.position = new Vector2(player.transform.position.x + trailPositionXLeft, player.transform.position.y + trailPositionY);

        backgroundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic");
        anim = GetComponent<Animator>();
        explosionSfx = GameObject.FindGameObjectWithTag("SliderMusic");
        joystick = FindObjectOfType<Joystick>();
        joyStickObj = GameObject.FindGameObjectWithTag("JoyStick");
        myBody = GetComponent<Rigidbody2D>();

        moveDirection = new Vector2(0, 1);
    }

    void Update()
    {
        //MOVEMENT
       stick = new Vector2(joystick.Horizontal, joystick.Vertical);

        // If the player leans the stick far enough, update our direction of movement.
        if (stick.sqrMagnitude >= joystickThreshold * joystickThreshold)
        {
            moveDirection = stick.normalized;
        }

        // Continue moving in the last chosen direction.
        myBody.velocity = moveDirection * moveSpeed;

        //This if statement makes the airplane face where the joystick is going.
        if (stick.sqrMagnitude >= 0.1f * 0.1f)
        {
            joypos = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
        }

        //rotation of the airplane
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -joypos), turnSpeed * Time.deltaTime);

        airplaneAnimation();

        if (resurrected)
        {
            adToResurrect.SetActive(false);
            resurrectButton.SetActive(true);
            ShieldSpawner.instance.shieldActivate.SetActive(true);

            resurrected = false;
            Time.timeScale = 0;
        }
       
    }

    public void airplaneAnimation()
    {
        switch (numberAnimChange)
        {
            case 0:
                anim.SetTrigger("Biplane");
                break;
            case 1:
                anim.SetTrigger("Spitfire");
                break;
            case 2:
                anim.SetTrigger("P51Mustang");
                break;
            case 3:
                anim.SetTrigger("Private Jet");
                break;
            case 4:
                anim.SetTrigger("Lockheed");
                break;
            case 5:
                anim.SetTrigger("Jetplane");
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //if airplaneShield is true than player won't be dead
            if (ShieldSpawner.instance.airplaneShield == false)
            {
                Sfx.PlaySound("explosionSound");
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);

                //If the player dies then turn off coin spawner.
                CoinSpawner.instance.allowedToSpawn = false;
                ShieldSpawner.instance.allowedToSpawn = false;

                //When enemy collides with player then the player explodes. 
                resurrected = true;

                backgroundMusic.GetComponent<AudioSource>().Pause();
                score.scoreGoing = false;
                ui.playerIsDead = true;
                enemySpawner.SetActive(false);
                gameObject.SetActive(false);

                //Restarts the rotation and the move direction of the player
                joypos = 0;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
                stick = new Vector2(0, 0);
                moveDirection = new Vector2(0, 1);

                explosion.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (ShieldSpawner.instance.airplaneShield == false)
            {
                //When the enemy collides with the player all the remaining enemies will also die.
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    explosion.GetComponent<SpriteRenderer>().enabled = true;
                    Instantiate(explosion, enemy.transform.position, Quaternion.identity);
                    enemy.SetActive(false);
                }
            }
        }
    }
}

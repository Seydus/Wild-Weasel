using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtonScript : MonoBehaviour
{
    public static InGameButtonScript instance;
    public static InGameButtonScript Instance { get { return instance; } }

    public GameUI inGameButton;

    public GameObject explosion;
    GameObject backgroundMusic;

    public GameObject player;

    public Animator transitionAnim;
    public GameObject resurrectButton;

    private void Start()
    {
        instance = this;
        backgroundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic");
    }

    public void cancelResurrection()
    {
        GameUI.instance.playerIsDead = false;
        GameUI.instance.cancelResurrect = true;
    }

    public void resurrectBack()
    {
        Time.timeScale = 1;

        //If the player resurrects then turn on coin spawner.
        CoinSpawner.instance.allowedToSpawn = true;
        ShieldSpawner.instance.allowedToSpawn = true;

        //When the player resurrects. 
        backgroundMusic.GetComponent<AudioSource>().Play();

        PlayerMovement.instance.isInGameMenuObj.SetActive(true);
        PlayerMovement.instance.enemySpawner.SetActive(true);
        PlayerMovement.instance.gameObject.SetActive(true);
        PlayerMovement.instance.joyStickObj.SetActive(true);
        PlayerMovement.instance.score.scoreGoing = true;

        ShieldSpawner.instance.airplaneShield = true;
        ShieldSpawner.instance.shieldBarImage.fillAmount = 1f;

        resurrectButton.SetActive(false);
    }

    public void resbutton()
    {
        if (inGameButton.isRestart == false)
        {
            Destroy(backgroundMusic);
            Sfx.PlaySound("playSound");
            //Destroy(backgroundMusic, .3f);
            inGameButton.isRestart = true;
        }
    }

    public void menbutton()
    {
        if (inGameButton.isMenu == false)
        {
            Sfx.PlaySound("playSound");
            StartCoroutine(Fade());
            Destroy(backgroundMusic, .15f);
            inGameButton.isMenu = true;

            //When the player goes to the menu, all the enemy will explode including the player.
            player.SetActive(false);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                explosion.GetComponent<SpriteRenderer>().enabled = true;
                Instantiate(explosion, enemy.transform.position, Quaternion.identity);
                Destroy(enemy);
            }
        }
    }

    public void InGam()
    {
        if (inGameButton.isInGameMenu == false)
        {
            Sfx.PlaySound("pressSound");
            inGameButton.isInGameMenu = true;
            ShieldSpawner.instance.airplaneShield = false;
        }
    }

    public void IsBack()
    {
        if (inGameButton.isBack == true)
        {
            Sfx.PlaySound("pressSound");
            inGameButton.isBack = false;
            ShieldSpawner.instance.airplaneShield = true;
        }
    }

    IEnumerator Fade()
    {
        transitionAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(.15f);
        SceneManager.LoadScene("menu");
    }
}

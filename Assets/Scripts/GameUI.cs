using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public bool playerIsDead = false;

    public bool isBack = false;
    public bool isRestart = false;
    public bool isMenu = false;
    public bool isInGameMenu = false;
    public bool cancelResurrect;

    public bool resurrect = false;

    public GameObject joyStickObj;
    public GameObject player;
    public GameObject isResObject;
    public GameObject isMenObject;
    public GameObject isBackObject;
    public GameObject cameraObj;
    public GameObject isInGameMenuObj;
    public GameObject highscore;
    public GameObject ads;

    public GameObject adsToSurvive;

    public AudioSource audioBack;

    public AdTimer adtimer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (resurrect)
        {
            player.SetActive(true);
            PlayerMovement.instance.resurrected = true;
            resurrect = false;
        }

        if (playerIsDead == false && cancelResurrect == true)
        {
            adsToSurvive.SetActive(false);

            highscore.SetActive(true);
            isResObject.SetActive(true);
            isMenObject.SetActive(true);
            ads.SetActive(true);

            joyStickObj.SetActive(false);
            isInGameMenuObj.SetActive(false);

            isBack = true;
            adtimer.adTimeBool = false;
            adtimer.adTimeResurrect = false;
            adtimer.adTimerImage.fillAmount = 1;
        }

        if (playerIsDead == true && ScoreUI.Instance.scoreAmount < 10)
        {
            highscore.SetActive(true);
            isResObject.SetActive(true);
            isMenObject.SetActive(true);
            ads.SetActive(true);

            joyStickObj.SetActive(false);
            isInGameMenuObj.SetActive(false);

            isBack = true;
        }
        else if (playerIsDead == true && ScoreUI.Instance.scoreAmount >= 10)
        {
            adtimer.adTimeBool = true;
            adsToSurvive.SetActive(true);
            playerIsDead = false;

            isBack = true;
        }

        if (isMenu)
        {
            Time.timeScale = 1;
        }

        if (isRestart == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (isInGameMenu == true)
        {
            joyStickObj.SetActive(false);
            isInGameMenuObj.SetActive(false);
            isResObject.SetActive(true);
            isMenObject.SetActive(true);
            isBackObject.SetActive(true);
            Time.timeScale = 0;
            isInGameMenu = false;
            isBack = true;
        }

        if (isBack == false)
        {
            joyStickObj.SetActive(true);
            isInGameMenuObj.SetActive(true);
            isResObject.SetActive(false);
            isMenObject.SetActive(false);
            isBackObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

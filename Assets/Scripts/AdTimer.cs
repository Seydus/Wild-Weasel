using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdTimer : MonoBehaviour
{
    public static AdTimer instance;

    public Image adTimerImage;

    [HideInInspector]
    public bool adTimeBool = false;
    [HideInInspector]
    public bool adTimeResurrect = false;

    public void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (adTimeBool == true)
        {
            adTimerImage.fillAmount -= 0.002f;

            if (adTimerImage.fillAmount <= 0)
            {
                GameUI.instance.playerIsDead = false;
                GameUI.instance.cancelResurrect = true;
            }
        }
    }
}

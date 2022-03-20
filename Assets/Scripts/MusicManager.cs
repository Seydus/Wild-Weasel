using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject Slider;



    void Start()
    {
        //PlayerPrefs for Music
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");

        //PlayerPrefs for SFX
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SfxVolume");
    }
}

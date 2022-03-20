using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Sprite[] airplane;
    public GameObject airplaneSkin;

    public int currentSkinIndex;
    public int currency;
    public int skinAvailability;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //We had a previous session
        currentSkinIndex = PlayerPrefs.GetInt("CurrentAirplane");
        currency = PlayerPrefs.GetInt("Currency");
        skinAvailability = PlayerPrefs.GetInt("SkinAvailability");

        airplaneSkin.GetComponent<SpriteRenderer>().sprite = airplane[currentSkinIndex];        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrentAirplane", currentSkinIndex);
        PlayerPrefs.SetInt("Currency", currency);
        PlayerPrefs.SetInt("SkinAvailability", skinAvailability);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public static Shop Instance { get { return instance; } }

    [HideInInspector]
    public int currentPlane;
    public int airplane1, airplane2, airplane3, airplane4, airplane5;
    int cost;

    int disableToPurchase;

    public GameObject airplaneContent;

    public Button[] planeAvailableButton;
    public int availablePlane;

    int selectedPlanes;
    public GameObject[] selected;

    public RectTransform rectAttributePos;

    private void Start()
    {
        selectedPlanes = PlayerPrefs.GetInt("planeSelectedNumber");

        //PlayerPrefs.SetInt("availablePlane", 1);
        availablePlane = PlayerPrefs.GetInt("availablePlane", 1);

        //Loops the number of array of the planes.
        for (int i = 0; i < planeAvailableButton.Length; i++)
        {
            //If the "i" is higher than the the "availablePlane" it disables the button interactable from the number of "i";
            if (i + 1 > availablePlane)
            planeAvailableButton[i].interactable = false;
        }

        disableToPurchase = 0;

        airplane1 = PlayerPrefs.GetInt("airplane1");
        airplane2 = PlayerPrefs.GetInt("airplane2");
        airplane3 = PlayerPrefs.GetInt("airplane3");
        airplane4 = PlayerPrefs.GetInt("airplane4");
        airplane5 = PlayerPrefs.GetInt("airplane5");

        currentPlane = PlayerPrefs.GetInt("CurrentAirplane");
        GameObject.Find("Airplane").GetComponent<SpriteRenderer>().sprite = GameManager.Instance.airplane[currentPlane];
    }

    private void Update()
    {
        #region currencyPriceInteractable
        if (airplane1 == 1)
        {
            airplaneContent.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("airplane1", airplane1);
        }
        if (airplane2 == 2)
        {
            airplaneContent.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("airplane2", airplane2);
        }
        if (airplane3 == 3)
        {
            airplaneContent.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("airplane3", airplane3);
        }
        if (airplane4 == 4)
        {
            airplaneContent.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("airplane4", airplane4);
        }
        if (airplane5 == 5)
        {
            airplaneContent.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("airplane5", airplane5);
        }

        if (airplane1 >= 6 || airplane2 >= 6 || airplane3 >= 6 || airplane4 >= 6 || airplane5 >= 6)
        {
            airplane1 = 0;
            airplane2 = 0;
            airplane3 = 0;
            airplane4 = 0;
            airplane5 = 0;
            PlayerPrefs.SetInt("airplane1", airplane1);
            PlayerPrefs.SetInt("airplane2", airplane2);
            PlayerPrefs.SetInt("airplane3", airplane3);
            PlayerPrefs.SetInt("airplane4", airplane4);
            PlayerPrefs.SetInt("airplane5", airplane5);
        }

        disableToPurchase -= 1;
        #endregion

        #region Lock Airplanes
        switch (availablePlane)
        {
            case 2:
                planeAvailableButton[1].interactable = true;
                PlayerPrefs.SetInt("availablePlane", availablePlane);
                break;
            case 3:
                planeAvailableButton[2].interactable = true;
                PlayerPrefs.SetInt("availablePlane", availablePlane);
                break;
            case 4:
                planeAvailableButton[3].interactable = true;
                PlayerPrefs.SetInt("availablePlane", availablePlane);
                break;
            case 5:
                planeAvailableButton[4].interactable = true;
                PlayerPrefs.SetInt("availablePlane", availablePlane);
                break;
        }
        #endregion

        #region Selected Plane
        switch (selectedPlanes)
        {
            case 0:
                selected[0].SetActive(true);
                selected[1].SetActive(false);
                selected[2].SetActive(false);
                selected[3].SetActive(false);
                selected[4].SetActive(false);
                selected[5].SetActive(false);
                break;
            case 1:
                selected[0].SetActive(false);
                selected[1].SetActive(true);
                selected[2].SetActive(false);
                selected[3].SetActive(false);
                selected[4].SetActive(false);
                selected[5].SetActive(false);
                break;
            case 2:
                selected[0].SetActive(false);
                selected[1].SetActive(false);
                selected[2].SetActive(true);
                selected[3].SetActive(false);
                selected[4].SetActive(false);
                selected[5].SetActive(false);
                break;
            case 3:
                selected[0].SetActive(false);
                selected[1].SetActive(false);
                selected[2].SetActive(false);
                selected[3].SetActive(true);
                selected[4].SetActive(false);
                selected[5].SetActive(false);
                break;
            case 4:
                selected[0].SetActive(false);
                selected[1].SetActive(false);
                selected[2].SetActive(false);
                selected[3].SetActive(false);
                selected[4].SetActive(true);
                selected[5].SetActive(false);
                break;
            case 5:
                selected[0].SetActive(false);
                selected[1].SetActive(false);
                selected[2].SetActive(false);
                selected[3].SetActive(false);
                selected[4].SetActive(false);
                selected[5].SetActive(true);
                break;
        }
        #endregion
    }

    public void setAirplane(int airplaneID)
    {
        if ((GameManager.Instance.skinAvailability & 1 << airplaneID) == 1 << airplaneID)
        {
            GameObject.Find("Airplane").GetComponent<SpriteRenderer>().sprite = GameManager.Instance.airplane[airplaneID];
            PlayerPrefs.SetInt("CurrentAirplane", airplaneID);

            switch (airplaneID)
            {
                case 0:
                    PlayerPrefs.SetInt("planeAnimNumber", 0);
                    PlayerPrefs.SetInt("planeSelectedNumber", 0);
                    selectedPlanes = 0;
                    break;
                case 1:
                    PlayerPrefs.SetInt("planeAnimNumber", 1);
                    PlayerPrefs.SetInt("planeSelectedNumber", 1);
                    selectedPlanes = 1;
                    break;
                case 2:
                    PlayerPrefs.SetInt("planeAnimNumber", 2);
                    PlayerPrefs.SetInt("planeSelectedNumber", 2);
                    selectedPlanes = 2;
                    break;
                case 3:
                    PlayerPrefs.SetInt("planeAnimNumber", 3);
                    PlayerPrefs.SetInt("planeSelectedNumber", 3);
                    selectedPlanes = 3;
                    break;
                case 4:
                    PlayerPrefs.SetInt("planeAnimNumber", 4);
                    PlayerPrefs.SetInt("planeSelectedNumber", 4);
                    selectedPlanes = 4;
                    break;
                case 5:
                    PlayerPrefs.SetInt("planeAnimNumber", 5);
                    PlayerPrefs.SetInt("planeSelectedNumber", 5);
                    selectedPlanes = 5;
                    break;
            }
        }
        else
        {
            //Amount of each airplanes
            switch (airplaneID)
            {
                case 1:
                    Sfx.PlaySound("pressSound");
                    cost = 200;
                    break;
                case 2:
                    Sfx.PlaySound("pressSound");
                    cost = 300;
                    break;
                case 3:
                    Sfx.PlaySound("pressSound");
                    cost = 400;
                    break;
                case 4:
                    Sfx.PlaySound("pressSound");
                    cost = 500;
                    break;
                case 5:
                    Sfx.PlaySound("pressSound");
                    cost = 600;
                    break;
            }

            if (GameManager.Instance.currency >= cost)
            {
                //If the player selects the price of the airplane then the airplane unlocks
                switch (cost)
                {
                    case 200:
                        airplane1 = 1;
                        availablePlane = 2; //Available to Unlock another plane
                        break;
                    case 300:
                        airplane2 = 2;
                        availablePlane = 3 ;//Available to Unlock another plane
                        break;
                    case 400:
                        airplane3 = 3;
                        availablePlane = 4 ;//Available to Unlock another plane
                        break;
                    case 500:
                        airplane4 = 4;
                        availablePlane = 5; //Available to Unlock another plane
                        break;
                    case 600:
                        airplane5 = 5;
                        break;
                }

                GameManager.Instance.currency -= cost;
                GameManager.Instance.skinAvailability += 1 << airplaneID;
                GameManager.Instance.Save();

                setAirplane(airplaneID);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneReplace : MonoBehaviour
{
    public static PlaneReplace instance;
    public static PlaneReplace Instance { get { return instance; } }

    public Shop shopAirplane;

    public void Airplane0()
    {
        shopAirplane.setAirplane(0);
        GameObject.Find("Airplane").GetComponent<SpriteRenderer>().sprite = GameManager.Instance.airplane[0];
        PlayerPrefs.SetInt("CurrentAirplane", 0);
    }
    public void Airplane1()
    {
        shopAirplane.setAirplane(1);
    }
    public void Airplane2()
    {
        shopAirplane.setAirplane(2);
    }
    public void Airplane3()
    {
        shopAirplane.setAirplane(3);
    }
    public void Airplane4()
    {
        shopAirplane.setAirplane(4);
    }
    public void Airplane5()
    {
        shopAirplane.setAirplane(5);
    }
}

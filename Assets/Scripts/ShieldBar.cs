using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public static ShieldBar instance;
    public static ShieldBar Instance { get { return instance; } }

    public Transform player;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Vector2 cameraWorld = Camera.main.WorldToScreenPoint(player.position);
        transform.position = cameraWorld;
    }
}

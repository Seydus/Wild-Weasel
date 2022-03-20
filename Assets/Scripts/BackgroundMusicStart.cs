using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicStart : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
    }
}

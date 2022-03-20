using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{

    public static AudioClip playSfx, pressSfx, explosionSfx, explosionEnemySfx, coinSfx;
    static AudioSource audioSrc;

    void Start()
    {
        playSfx = Resources.Load<AudioClip>("playSound");
        pressSfx = Resources.Load<AudioClip>("pressSound");
        explosionSfx = Resources.Load<AudioClip>("explosionSound");
        explosionEnemySfx = Resources.Load<AudioClip>("explosionSound");
        coinSfx = Resources.Load<AudioClip>("coinSound");


        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playSound":
                audioSrc.PlayOneShot(playSfx);
                break;
            case "pressSound":
                audioSrc.PlayOneShot(pressSfx);
                break;
            case "explosionSound":
                audioSrc.PlayOneShot(explosionSfx);
                break;
            case "explosiondSoundEnemy":
                audioSrc.PlayOneShot(explosionEnemySfx);
                break;
            case "coinSound":
                audioSrc.PlayOneShot(coinSfx);
                break;
        }
    }
}

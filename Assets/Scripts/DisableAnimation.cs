using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimation : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(disableObject());
    }

    IEnumerator disableObject()
    {
        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}

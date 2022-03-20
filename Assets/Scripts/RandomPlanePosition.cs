using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlanePosition : MonoBehaviour
{

    private void Awake()
    {
        float x = Random.Range(Camera.main.WorldToScreenPoint(new Vector2(0, 0)).x, Camera.main.WorldToScreenPoint(new Vector2(5, 0)).x);
        float y = Random.Range(Camera.main.WorldToScreenPoint(new Vector2(0, 0)).y, Camera.main.WorldToScreenPoint(new Vector2(0, 5)).y);

        transform.position = new Vector2(x, y);
    }
}

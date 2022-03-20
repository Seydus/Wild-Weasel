using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject targetToFollow;

    void Update()
    {
        transform.position = new Vector3(targetToFollow.transform.position.x, targetToFollow.transform.position.y - 1.7f, transform.position.z);
    }
}

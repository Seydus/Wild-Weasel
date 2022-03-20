using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{
    public float parralax;

    public Transform cameraFollow;
    Vector2 offset;
    MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Material mat = mr.material;

        offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;

        mat.mainTextureOffset = offset;

        //Follow camera
        Vector3 followcam = new Vector3(cameraFollow.position.x, cameraFollow.position.y, transform.position.z);
        transform.position = followcam;
    }
}

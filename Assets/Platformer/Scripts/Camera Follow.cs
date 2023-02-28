using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float deltax;
    public float cameraY;
    public float cameraZ;

    void Start()
    {
        deltax = Mathf.Abs(player.transform.position.x - transform.position.x);
        cameraY = transform.position.y;
        cameraZ = transform.position.z;
    }

    void Update()
    {
        SetCamera();
    }

    void SetCamera()
    {
        transform.position = new Vector3(player.transform.position.x + deltax, cameraY, cameraZ);
    }
}
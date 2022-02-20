﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if(playerTransform != null)
        {
            Vector3 temp = transform.position;
            temp.x = playerTransform.position.x;
            temp.y = playerTransform.position.y;
            transform.position = temp;
        }
    }
}

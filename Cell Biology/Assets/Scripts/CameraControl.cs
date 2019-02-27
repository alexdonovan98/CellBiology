﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    private GameObject player; 
    private Vector3 offset;       

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player){
            offset = transform.position - player.transform.position;
        }
    }

    void LateUpdate()
    {
        if (player)
        {
            transform.position = player.transform.position + offset;
        }

        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player) {
                offset = transform.position - player.transform.position;
            }
        }


    }
}
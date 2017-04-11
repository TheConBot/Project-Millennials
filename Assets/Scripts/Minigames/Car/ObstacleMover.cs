﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour {

    public float speed = 5;
    public float zThreshhold = -25;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, zThreshhold), Time.deltaTime * speed);
        if(transform.position.z <= zThreshhold)
        {
            Destroy(this);
        }
    }
}
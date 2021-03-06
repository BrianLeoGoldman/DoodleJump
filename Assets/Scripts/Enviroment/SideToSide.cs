﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour {

    public float platformSpeed = 2f;
    bool endPoint;

	void Update () {

        if (endPoint)
        {
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

        if(transform.position.x >= 3.25)
        {
            endPoint = false;
        }
        if (transform.position.x <= -3.25)
        {
            endPoint = true;
        }
    }
}

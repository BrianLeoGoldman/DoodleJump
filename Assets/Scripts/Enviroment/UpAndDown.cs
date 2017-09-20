using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour {

    public float platformSpeed = 2f;  
    bool limitPoint;

    float startPoint;
    float endPoint;
    public int unitsToMove = 2;

    void Start () {

        startPoint = transform.position.y;

        endPoint = startPoint + unitsToMove;
	}

	void Update () {

        if (limitPoint)
        {
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
        }

        if (transform.position.y >= endPoint)
        {
            limitPoint = false;
        }
        if (transform.position.y <= startPoint)
        {
            limitPoint = true;
        }
    }
}

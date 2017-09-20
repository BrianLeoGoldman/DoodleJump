using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Transform camera;  //Object to track

    void Start () {

        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }
	
	void Update () {

        Vector3 cameraPosition = new Vector3(camera.position.x, camera.position.y, 0.1f);
        transform.position = cameraPosition;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWrap : MonoBehaviour {

    public float screenLimit = 4.60f;

	void FixedUpdate () {

        if(transform.position.x <= -screenLimit)  //If the character exits the screen on the left...
        {
            transform.position = new Vector3(screenLimit, transform.position.y, transform.position.z);  //then it appears on the right side of the screen
        }
        else if(transform.position.x >= screenLimit)  //If the character exits the screen on the right...
        {
            transform.position = new Vector3(-screenLimit, transform.position.y, transform.position.z);  //then it appears on the left side of the screen
        }
		
	}
}

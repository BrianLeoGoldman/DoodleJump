using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform player;  //Object to track
    float playerHeightY;  //Position of the player on the Y axis
    float currentCameraHeight;  //Position of the camera on the Y axis
    float newCameraHeight;  //Adjustment of the camera on the Y axis
    
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;  //Finds our player GameObject using the player tag
    }
	
	void Update () {

        playerHeightY = player.position.y;  //Tracks the players position on the Y axis

        currentCameraHeight = transform.position.y;  //Tracks the camera current position on the Y axis
        newCameraHeight = Mathf.Lerp(currentCameraHeight, playerHeightY, Time.deltaTime * 10);  //Adjustement of the camera height

        if (playerHeightY > currentCameraHeight)  //If the players current postion on the Y axis is higher than the camera current position on the Y axis
        {
            transform.position = new Vector3(transform.position.x, newCameraHeight, transform.position.z);  //Apply the adjustement to the camera position on the Y axis
        }
        else
        {
            if (playerHeightY < currentCameraHeight - 5.64f)  //If the players height falls below a the lower limit of the camera
            {
                ScoreDisplay.display.CheckMaxScoreAndCoins();  //Checks if there is a new maxScore or a maxCoins
                Application.LoadLevel(Application.loadedLevel);  //The level restarts
            }
        }
    }
}

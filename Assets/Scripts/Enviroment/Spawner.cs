using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    
    public Transform player;  //Object to track
    float playerHeightY;  //Height at wich the camera will adjust to

    public Transform staticPlatform;  //Variable to store a platform prefab
    public Transform horizontalPlatform;  //Variable to store a platform prefab
    public Transform verticalPlatform;  //Variable to store a platform prefab
    public Transform boostBlock;  //Variable to store a platform prefab
    public Transform coin;  //Variable to store a coin prefab
    public List<Transform> spawnedObjects;  //List of spawned platforms and coins

    private int platformNumber;  //Number between 1 and 4 asigned to a specific prefab platform
    private float platformCheck;  //Number to check if the player is near and in that case spawn platforms
    private float spawnPlatformsTo;  //Previous location platforms were spawn from

    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;  //Finds our player GameObject using the player tag
        spawnedObjects = new List<Transform>();
        PlatformManager();
    }
	
	void Update () {

        playerHeightY = player.position.y;  //Tracks the players position on the Y axis

        if (playerHeightY > platformCheck)  //If the players position on the y axis is more than the position to check
        {
            PlatformManager();  //Call the PlatformManager() method
        }

    }

    private void PlatformManager()
    {
        platformCheck = player.position.y + 15;  //Moves the point to check upwards
        PlatformSpawner(platformCheck + 15);  //Calls the PlatformSpawner() method with a limit value to spawn platforms
        foreach (var elem in spawnedObjects)  //For each spawned object in the list
        {
            if (elem != null && elem.position.y < (player.position.y - 20))  //If it is an exiting object below the camera reach
            {
                Destroy(elem.gameObject);  //Destroy the object
            }

        }

    }

    private void PlatformSpawner(float floatValue)
    {
        float y = spawnPlatformsTo;  //Sets the y value (the height of the spawning platforms) at the height of the last spawned platform

        while (y <= floatValue)  //Spawns platforms until the loop reaches the flotValue
        {
            float x = UnityEngine.Random.Range(-3.25f, 3.25f);  //Randomly sets the x position of the platform to spawn

            platformNumber = UnityEngine.Random.Range(1, 5);  //Randomly selects the type of platform to spawn

            Vector2 posXY = new Vector2(x, y);  //Sets the position of the new platform to spawn (using the random x value and the increasing y value)
            
            if (platformNumber == 1)  //If the random number was one
            {
                Transform p, c1, c2, c3;
                p = Instantiate(staticPlatform, posXY, Quaternion.identity);  //Spawns a static platform  
                spawnedObjects.Add(p);  //Adds the platform to the list

                c1 = Instantiate(coin, new Vector2(x - 2, y + 2), Quaternion.identity);  //Spawns a coin
                c2 = Instantiate(coin, new Vector2(x, y + 2), Quaternion.identity);  //Spawns a coin
                c3 = Instantiate(coin, new Vector2(x + 2, y + 2), Quaternion.identity);  //Spawns a coin
                spawnedObjects.Add(c1);  //Adds the coin to the list
                spawnedObjects.Add(c2);  //Adds the coin to the list
                spawnedObjects.Add(c3);  //Adds the coin to the list

            }
            if (platformNumber == 2)  //If the random number was two
            {
                Transform p;
                p = Instantiate(horizontalPlatform, posXY, Quaternion.identity);  //Spawns a platform that moves from side to side
                spawnedObjects.Add(p);  //Adds the platform to the list
            }
            if (platformNumber == 3)  //If the random number was three
            {
                Transform p;
                p = Instantiate(verticalPlatform, posXY, Quaternion.identity);  //Spawns a platform that moves up and down
                spawnedObjects.Add(p);  //Adds the platform to the list
            }
            if (platformNumber == 4)  //If the random number was four
            {
                Transform p;
                p = Instantiate(boostBlock, posXY, Quaternion.identity);  //Spawns a boost block
                spawnedObjects.Add(p);  //Adds the platform to the list
            }
            

            y += UnityEngine.Random.Range(2.0f, 4.00f);  //Randomly increases the height of the next platform to spawn

            Debug.Log("Spawned Platform");  //Prints a message in the console every time a platform is spawned
        }

        spawnPlatformsTo = floatValue;  //Sets the previous location platforms were spawned, so in the next loop no platform is spawned below this position



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour {
    
    public float movementSpeed = 4f;

    void Update () {

        //Allows player to move using LEFT/RIGHT or A/D
        Vector2 posX = transform.position;  //Current character position
        float horizontal = Input.GetAxis("Horizontal");  //Movement value set by the player
        Vector2 velocityX = new Vector2(horizontal * movementSpeed * Time.deltaTime, 0);  //New velocity of the character
        posX += velocityX;  //New position of the character based on the new velocity
        transform.position = posX;  //Change of character position

        //Other way: in this case the character rotates as it moves if it has a circular shape
        //GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);

    }
}

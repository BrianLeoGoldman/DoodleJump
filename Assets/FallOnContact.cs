using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnContact : MonoBehaviour {

    public float falling = 50f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player") 
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);  //Turns current velocity to zero
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -falling));  

        }
    }
}

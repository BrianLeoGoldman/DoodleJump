using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBoost : MonoBehaviour
{
    public AudioClip soundClip;
    public AudioSource soundEffect;
    public float jumpHeight = 1000f;  //Characters jump height when hitting the power up
    float velocityY;  //Variable that can be seen and referenced throughout the script

    void Start()
    {
        soundEffect.clip = soundClip;

    }

    void Update()
    {

        velocityY = GetComponent<Rigidbody2D>().velocity.y;  //References the characters current velocity

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "JumpBoost" && velocityY <= 0)  //If character collides with Boost platform and he is falling down
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);  //Turns current velocity to zero
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight));  //Makes the character jump
            soundEffect.Play();  //Play the sound
        }
    }
}

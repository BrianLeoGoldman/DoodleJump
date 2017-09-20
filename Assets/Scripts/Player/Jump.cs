using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public AudioClip soundClip;
    public AudioSource soundEffect;
    public bool grounded;  //True or false based on whether the character is on the ground
    public float jumpHeight = 500f;  //The character jump height

    public Transform groundCheck;  //Object that will check if the character is grounded

    public float groundRadius = .2f;  //Radius around the groundcheck object that detects if the character is grounded or not
    public LayerMask ground;  //Decide which layers count as grounded

    void Start()
    {
        soundEffect.clip = soundClip;
    }

	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);  //Checks if the character is on the ground or not

        float velY = GetComponent<Rigidbody2D>().velocity.y;

        if (grounded && velY <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);  //Reduce characters speed to zero
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight));  //Jumps
            soundEffect.Play();
        }
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour {

    private SpriteRenderer mySpriteRenderer;
    public Sprite jumping;
    public Sprite falling;
    public Sprite bouncing;

    void Start () {

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = jumping;

    }
	
	void Update () {

        CheckSides();
        CheckSprites();

    }

    private void CheckSides()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            mySpriteRenderer.flipX = true;  //Flip the sprite
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            mySpriteRenderer.flipX = false;  //Flip the sprite
        }
    }

    private void CheckSprites()
    {
        float velY = GetComponent<Rigidbody2D>().velocity.y;

        if (velY > 0)
        {
            mySpriteRenderer.sprite = jumping;
        }
        if (velY < 0)
        {
            mySpriteRenderer.sprite = falling;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            mySpriteRenderer.sprite = bouncing;
            
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -20f)); 
        }

    }


}

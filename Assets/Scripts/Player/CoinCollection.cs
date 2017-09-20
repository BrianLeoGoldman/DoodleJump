using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour {

    public AudioClip soundClip;
    public AudioSource soundEffect;
    CoinManager manager;

	void Start () {
        soundEffect.clip = soundClip;
        manager = GameObject.Find("GameManager").GetComponent<CoinManager>();  //Finds the GameManager object
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin")  //If the other object is a coin
        {
            manager.CoinCollected();  //The GameManager counts the coin as collected
            soundEffect.Play();  //Play the sound
            Destroy(other.gameObject);  //Destroy the coin
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour 
{

	private PlayerController2 thePlayer;

	// Use this for initialization
	void Start () 
    {
		thePlayer = FindObjectOfType<PlayerController2> ();	
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Player"){
			thePlayer.hurt ();	 
		}

	}
}

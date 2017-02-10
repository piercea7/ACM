using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	/* Stats for hero */
	public int Health = 1000; // health all characters will have 1000 hp
	public float Agility = 1f; // handles the jumps


	/******************/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			//Handle collisions here
				//Tag: Player -- the player
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSoundController : MonoBehaviour {

	public float normalSpeed = 1f;
	public AudioSource source;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	// play sound on collision
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "BouncePad") {
            // pitch determined by velocity of bead
            Vector3 vel = gameObject.GetComponent<Rigidbody>().velocity;
            source.pitch = vel.magnitude / normalSpeed; 
			source.Play();
		}
	}
}

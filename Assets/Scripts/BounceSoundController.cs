using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSoundController : SpawnableObject {

	public float normalSpeed = 1f;
	private AudioSource source;


	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// play sound on collision
	void OnCollisionEnter(Collision col){
		if (state & col.gameObject.tag == "Bead") {
            // pitch determined by velocity of bead
            Vector3 vel = col.gameObject.GetComponent<Rigidbody>().velocity;
            source.pitch = vel.magnitude / normalSpeed;
			source.Play();
		}
	}
}

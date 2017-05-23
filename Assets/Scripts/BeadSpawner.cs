using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadSpawner : SpawnableObject {

	public float beadSize = 0.5f; // should be set by spawner scale
	public float exitVelocity = 3f;
	public GameObject bead;
	public float bpm = 60f;
    public Transform spawnPoint;
	float period;


	// Use this for initialization
	void Start () {
		period = 60f / bpm;
		InvokeRepeating("CreateBead", 1.0f, period);
	}

	// Update is called once per frame																																																
	void Update () {
		
	}

	// Spawns a bead if enabled
	void CreateBead(){
        if (state)
        {
            GameObject clone = Instantiate(bead, spawnPoint.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().velocity = spawnPoint.TransformDirection(Vector3.up * exitVelocity);
        }
	}
}

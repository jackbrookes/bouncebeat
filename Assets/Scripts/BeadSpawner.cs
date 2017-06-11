using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BeadSpawner : SpawnableObject {

	public float beadSize = 0.5f; // should be set by spawner scale
	public float exitVelocity = 3f;
	public GameObject bead;
	public float bpm = 60f;
    public Transform spawnPoint;
	float period;
    public GameObject uiGo;
    Canvas ui;
    CanvasScaler cs;

	// Use this for initialization
	void Start () {
        ui = uiGo.GetComponentInChildren<Canvas>();
        cs = uiGo.GetComponentInChildren<CanvasScaler>();
        period = 60f / bpm;
        StartCoroutine(WaitAndCreate());
    }

	// Update is called once per frame																																																
	void Update () {

		if (isGrabbed)
        {
            // add animation here
            ui.enabled = true;
            cs.enabled = true;
        } else
        {
            ui.enabled = false;
            cs.enabled = false;
        }

    }

	// Spawns a bead if enabled
	void CreateBead(){
        if (state)
        {
            GameObject clone = Instantiate(bead, spawnPoint.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().velocity = spawnPoint.TransformDirection(Vector3.up * exitVelocity);
        }
	}

    private IEnumerator WaitAndCreate()
    {
        while (true)
        {
            period = 60f / bpm;
            yield return new WaitForSeconds(period);
            CreateBead();
        }
    }

    public override void StateSet(bool value)
    {

    }

}

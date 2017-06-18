using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSelector : MonoBehaviour {

    public BeadSpawner beadSpawner;
    List<AudioClip> clipList;
    private int index = 0;

	// Use this for initialization
	void Start () {
        clipList = GameObject.Find("Master").GetComponent<GameController>().clipList;
        beadSpawner.currentClip = clipList[index];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cycle (bool direction)
    {
        index = direction ? (index + 1) : (index - 1);
        if (index >= clipList.Count) index = 0;
        else if (index < 0) index = clipList.Count;
        beadSpawner.currentClip = clipList[index];
        //updateUI
    }

}

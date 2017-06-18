using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<AudioClip> baseClipList;
    [HideInInspector]
    public List<AudioClip> clipList;

	void Awake () {
        BuildSoundsList();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void BuildSoundsList()
    {
        clipList = baseClipList;
    }

}

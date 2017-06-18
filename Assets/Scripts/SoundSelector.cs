using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSelector : MonoBehaviour {

    public BeadSpawner beadSpawner;
    List<AudioClip> clipList;
    private int index = 0;
    public Text clipText;

	// Use this for initialization
	void Start () {
        clipList = GameObject.Find("Master").GetComponent<GameController>().clipList;
        Cycle(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cycle (int offset)
    {
        index += offset;
        if (index >= clipList.Count) index = 0;
        else if (index < 0) index = clipList.Count - 1;
        beadSpawner.currentClip = clipList[index];
        clipText.text = "< " + clipList[index].name + " >";
    }

}

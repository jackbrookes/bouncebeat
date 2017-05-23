using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOverride : MonoBehaviour {

    public GameObject realObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetNewObjectInstance()
    {
        GameObject newInstance = Instantiate(realObject);
        newInstance.transform.position = transform.position;
        newInstance.transform.rotation = transform.rotation;
        return newInstance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandController : MonoBehaviour {

    public bool flipped;
    public GameObject handOverlay;
    GameObject handOverlayInstance;

	// Use this for initialization
	void Start () {
        handOverlayInstance = Instantiate(handOverlay, transform);
        if (flipped)
        {

            for (int i=0; i< handOverlayInstance.transform.childCount; i++)
            {
                Transform c = handOverlayInstance.transform.GetChild(i);
                c.position = Vector3.Scale(c.position, new Vector3(-1, 1, 1));
            }


            RectTransform uiRect = handOverlayInstance.GetComponentInChildren<RectTransform>();
            uiRect.Rotate(new Vector3(0, 180, 0));

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristOverlayController : MonoBehaviour {

    public float threshold = 0f;
    public Transform alignVector;
    Transform head;
    [SerializeField]
    bool lastFrameState = false;

    // Use this for initialization
    void Start () {
        head = GameObject.Find("CenterEyeAnchor").transform;        
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 forward = head.TransformDirection(Vector3.forward);
        Vector3 alligner = alignVector.TransformDirection(Vector3.forward);
        float dot = Vector3.Dot(forward.normalized, alligner.normalized);

        bool currState = dot > threshold;

        if (lastFrameState != currState)
        {
            Animate(currState);
            lastFrameState = currState;
        }
        
    }

    void Animate(bool state)
    {
        foreach(MeshRenderer render in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            render.enabled = state;
        }        
    }
}

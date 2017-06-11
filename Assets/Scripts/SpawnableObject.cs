using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour {

    bool _state = true;
    OVRGrabbable ovrg;

    void Awake()
    {
        ovrg = GetComponent<OVRGrabbable>();
    }

    public bool isGrabbed
    {
        get {
            if (ovrg) {
                return ovrg.isGrabbed;
            } else
            {
                return false;
            }
        }
    }


    public Vector2 thumbPad
    {
        get
        {
            if (isGrabbed) return ovrg.m_grabbedBy.thumbPad;
            else return Vector2.zero;
        }
    }

    public bool state
    {
        get
        {
            return _state;
        }
        set
        {
            StateSet(value);
            if (value == true)
            {
                ovrg = GetComponent<OVRGrabbable>();
                _state = true;
            } else
            {
                ovrg = null;
                _state = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public virtual void StateSet(bool value) { }

}

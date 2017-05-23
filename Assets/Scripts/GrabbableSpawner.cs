using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableSpawner : OVRGrabbable {

    public GameObject realObjectPrefab;

	// Use this for initialization
	public override void Start () {
       // nothing
    }

    public override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update () {
		
	}

    // overrides grab begin function, which then switches the hologram with a newly spawned 'real' object
    public override OVRGrabbable GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        GameObject realObject = Instantiate(realObjectPrefab);
        realObject.transform.position = transform.position;
        realObject.transform.rotation = transform.rotation;

        OVRGrabbable newGrabbable = realObject.GetComponent<OVRGrabbable>();
        newGrabbable.m_grabbedBy = hand;
        newGrabbable.m_grabbedCollider = realObject.GetComponent<Collider>();


        return newGrabbable;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramController : MonoBehaviour {

    public Material holoMaterial;
    public GameObject objectToSpawn;
    public Transform hologramLocation;
    public float rotSpeed = 20f;
    GameObject hologram;

	// Use this for initialization
	void Start () {
        MakeHolo();
    }
	
	// Update is called once per frame
	void Update () {
		if (hologram)
        {
            hologram.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
	}

    [ContextMenu("Make Holo")]
    void MakeHolo()
    {

        // make hologram

        hologram = Instantiate(objectToSpawn);
        DestroyImmediate(hologram.GetComponent<OVRGrabbable>());
        DestroyImmediate(hologram.GetComponent<Rigidbody>());
        hologram.GetComponent<SpawnableObject>().state = false;
        hologram.transform.SetParent(hologramLocation, false);
        hologram.transform.localPosition = Vector3.zero;
        hologram.transform.localRotation = Quaternion.Euler(Vector3.zero);
        Renderer[] children = hologram.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in children)
        {
            r.material = holoMaterial;
        }
        hologram.GetComponent<Collider>().isTrigger = true;
        

        // adds a script which will act as a fake OVRGrabber, but will return a real object when grabbed
        GrabbableSpawner gs = hologram.AddComponent<GrabbableSpawner>();
        gs.realObjectPrefab = objectToSpawn;



    }

}

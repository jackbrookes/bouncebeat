using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCamera : MonoBehaviour {

    Transform head;

    // Use this for initialization
    void Start () {
        head = GameObject.Find("CenterEyeAnchor").transform;
    }

    // Update is called once per frame
    void Update () {

        // smooth look at head
        transform.rotation = Quaternion.Slerp(transform.rotation, head.rotation, Time.deltaTime * 10f);

    }
}

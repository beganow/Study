using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Quaternion : MonoBehaviour {
    private Quaternion startingRotation = new Quaternion();
    float angle;
    // Use this for initialization
    void Start () {
        startingRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        angle += 1f;

        Quaternion Rotation_x = Quaternion.AngleAxis(angle, Vector3.right); // ось X
        Quaternion Rotation_z = Quaternion.AngleAxis(angle, Vector3.forward); // ось Z

        Quaternion rotation = startingRotation * Rotation_x * Rotation_z;

        transform.rotation = rotation;
    }
}

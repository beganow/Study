using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Euler : MonoBehaviour
{
    float angle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angle += 1f;
        transform.eulerAngles = new Vector3(angle, 0, angle);
    }
}

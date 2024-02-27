using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    float get_x;
    float get_z;

    public GameObject Capsule;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        get_x = Input.GetAxis("Horizontal");
        get_z = Input.GetAxis("Vertical");

        transform.Translate(get_x, 0, get_z);

    
    }

}

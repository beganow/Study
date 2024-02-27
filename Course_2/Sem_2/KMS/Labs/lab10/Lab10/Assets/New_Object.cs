using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Object : MonoBehaviour {

    public GameObject prefub1;
    public Vector3 startpos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0f, 10f, 0f);

            Rigidbody rigcube = cube.AddComponent<Rigidbody>();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 45f));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -45f));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefub1, startpos + Vector3.up * 10f, Quaternion.identity);
        }
    }
}

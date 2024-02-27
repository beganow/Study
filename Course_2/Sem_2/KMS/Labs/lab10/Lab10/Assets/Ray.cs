using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour {

    private Camera cam1;

    // Use this for initialization
    void Start()
    {
        cam1 = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam1.pixelWidth / 2, cam1.pixelHeight / 2 + 60, 0);
            UnityEngine.Ray ray = cam1.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Vector3 pos = hit.point;
                sphere.transform.position = pos;
            }
        }
    }
}

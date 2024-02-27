using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
     public float moveSpeed = 5f;
    private Rigidbody rb;
    public GameObject robot;
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = 0f;
        float moveVertical = 0f;

   
        if (Input.GetKey(KeyCode.E))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            moveVertical = -1f;
        }
        else if (Input.GetKey(KeyCode.T))
        {
            moveHorizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            moveHorizontal = 1f;
        }

     
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

       
        robot.transform.position = transform.position + movement;
    }
}

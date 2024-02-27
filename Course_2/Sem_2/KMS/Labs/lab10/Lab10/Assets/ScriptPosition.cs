using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        float speedX = 0.3f; // скорость перемещения объекта
        float speedY = 0.2f;
        float speedZ = 0.1f;
        float stepX = speedX * 2; 
        Vector3 newPosition = transform.position;
        newPosition.x += stepX;
        newPosition.y += speedY;
        newPosition.z += speedZ;

        transform.position = newPosition;
    }
}

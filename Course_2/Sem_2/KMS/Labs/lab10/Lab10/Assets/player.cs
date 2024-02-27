using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame


   

    private void Update()
    {
        // Получаем значения ввода для перемещения по горизонтали (клавиши A и D)
        float horizontalInput = Input.GetAxis("Horizontal");
        // Получаем значения ввода для перемещения по вертикали (клавиши W и S)
        float verticalInput = Input.GetAxis("Vertical");
        // Получаем значение ввода для вращения мыши вокруг вертикальной оси
        float mouseXInput = Input.GetAxis("Mouse X");

        // Перемещаем персонажа по горизонтали
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Вращаем персонажа вокруг вертикальной оси мыши
        float rotation = mouseXInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
}

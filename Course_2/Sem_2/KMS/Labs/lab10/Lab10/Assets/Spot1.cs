using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot1 : MonoBehaviour
{
    public GameObject player;
    public Light spotLight;
    public float rotationSpeed = 5f;

    private bool isPlayerInsideTrigger = false;

    private void Update()
    {
        if (spotLight.enabled)
        {
            RotateSpotLight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            spotLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            spotLight.enabled = false;
        }
    }

    private void RotateSpotLight()
    {
        // Вращение источника света вокруг вертикальной оси
        spotLight.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
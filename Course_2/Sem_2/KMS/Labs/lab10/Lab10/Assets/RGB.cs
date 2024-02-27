using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour {

    public Light pointLight1;
    public Light pointLight2;
    public Light pointLight3;
    public GameObject cylinder;
    public GameObject player;
    Vector3 cylinderposition;
    private float gateOffset = 1f;
    public float openAngle1 = -90f;
    private Quaternion cylinderRotation;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    public float rotationSpeed = 30f;

    private bool isInsideTrigger;

    private void Start()
    {
        // Инициализируем начальную интенсивность источников света
        SetLightIntensity(minIntensity);
        cylinderposition = cylinder.transform.position;
        cylinderRotation = cylinder.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если объект, вошедший в триггер, является персонажем
        if (other.gameObject == player)
        {
            isInsideTrigger = true;
            pointLight1.enabled = true;
            pointLight2.enabled = true;
            pointLight3.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, если объект, вышедший из триггера, является персонажем
        if (other.gameObject == player)
        {
            isInsideTrigger = false;
            pointLight1.enabled = false;
            pointLight2.enabled = false;
            pointLight3.enabled = false;
            CylinderReset();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Проверяем, если объект находится внутри триггера и является персонажем
        if (isInsideTrigger && other.gameObject == player)
        {
            // Плавно изменяем интенсивность источников света
            float t = Mathf.PingPong(Time.time, 1f);
            float intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
            SetLightIntensity(intensity);
            Vector3 newPosition = cylinderposition;
            newPosition.y += gateOffset;
            newPosition.z += gateOffset;
            cylinder.transform.position = newPosition;
            Vector3 rotation = cylinder.transform.rotation.eulerAngles;
            rotation.y += rotationSpeed * Time.deltaTime * 2;
            rotation.z += rotationSpeed * Time.deltaTime * 2;
            cylinder.transform.rotation = Quaternion.Euler(rotation);
            // Вращаем цилиндр
        }
    }

    private void SetLightIntensity(float intensity)
    {
        pointLight1.intensity = intensity;
        pointLight2.intensity = intensity;
        pointLight3.intensity = intensity;
    }
    private void CylinderReset()
    {
        cylinder.transform.position = cylinderposition;
        cylinder.transform.rotation = cylinderRotation;
    }
}

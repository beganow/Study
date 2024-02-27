using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vorota : MonoBehaviour
{
    public GameObject player;
    public GameObject gate1; // Ссылка на объект ворот
    public GameObject gate2; // Ссылка на объект ворот
    public GameObject FlyingCube;
    public GameObject Robot;
    public float openAngle = 90f; // Угол открытия ворот
    public float openAngle1 = -90f; // Угол открытия ворот
    private bool isInsideTrigger; // Флаг для отслеживания нахождения персонажа в триггере
    private Quaternion closedRotation1; // Исходная (закрытая) ориентация ворот
    private Quaternion closedRotation2; // Исходная (закрытая) ориентация ворот
    private Quaternion cubeRotation;
    public float gateOffset = 0.86f;
    public float CubeOffset = 2f;
    public float CubeOffset1 = -10f;
    // Смещение ворот по оси X
    private Vector3 closedPosition1; // Исходная (закрытая) позиция ворот
    private Vector3 closedPosition2; // Исходная (закрытая) позиция ворот
    private Vector3 cubePosition; // Исходная (закрытая) позиция ворот


    private void Start()
    {
        closedRotation1 = gate1.transform.rotation;
        closedPosition1 = gate1.transform.position;
        closedRotation2 = gate2.transform.rotation;
        closedPosition2 = gate2.transform.position;
        cubePosition = FlyingCube.transform.position;
        cubeRotation = FlyingCube.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если объект, вошедший в триггер, является персонажем
        if (other.gameObject == player)
        {
            isInsideTrigger = true;
            OpenGate();
        }
        if (other.gameObject == Robot)
        {
            isInsideTrigger = true;
            RotateFlyCube();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, если объект, вышедший из триггера, является персонажем
        if (other.gameObject == player)
        {
            isInsideTrigger = false;
            CloseGate();
        }
        if (other.gameObject == Robot)
        {
            isInsideTrigger = false;
            ResetFlyCube();
        }
    }

    private void OpenGate()
    {
        // Поворачиваем ворота в открытое положение
        gate1.transform.rotation = Quaternion.Euler(0f, openAngle, 0f);
        // Смещаем ворота по оси X
        Vector3 newPosition = closedPosition1;
        newPosition.x -= gateOffset;
        gate1.transform.position = newPosition;
        gate2.transform.rotation = Quaternion.Euler(0f, openAngle1, 0f);
        // Смещаем ворота по оси X
        Vector3 newPosition2 = closedPosition2;
        newPosition2.x += gateOffset;
        gate2.transform.position = newPosition2;
    }

    private void RotateFlyCube()
    {
        StartCoroutine(MoveCubeCoroutine());
    }

    private IEnumerator MoveCubeCoroutine()
    {
        Vector3 startPosition = FlyingCube.transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0f, CubeOffset, CubeOffset1);
        float duration = 5f; // Продолжительность движения (в секундах)
        float elapsedTime = 0f; // Прошедшее время

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Прогресс движения (от 0 до 1)
            FlyingCube.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Установка конечной позиции после завершения движения
        FlyingCube.transform.position = targetPosition;
    }

    private void CloseGate()
    {
        gate1.transform.rotation = closedRotation1;
        gate1.transform.position = closedPosition1;
        gate2.transform.rotation = closedRotation2;
        gate2.transform.position = closedPosition2;

    }

    private void ResetFlyCube()
    {
        FlyingCube.transform.rotation = cubeRotation;
        FlyingCube.transform.position = cubePosition;
    }
}

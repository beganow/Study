using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLight : MonoBehaviour {

    public Light doorLight; // Объектная переменная, связанная с источником света

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player") // Проверяем, если персонаж попадает в триггер
        {
            doorLight.enabled = true; // Включаем свет
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player") // Проверяем, если персонаж покидает триггер
        {
            doorLight.enabled = false; // Выключаем свет
        }
    }
}

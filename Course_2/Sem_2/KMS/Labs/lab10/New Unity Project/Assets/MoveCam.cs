using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{

    bool move = false;
    float speed = 0.01f;
    float offset = 0;
    Vector3 startPosition;
    Vector3 needPosition;
    Quaternion startRotation;
    Quaternion needRotaton;
    public void Move0()     //функция для начального положения
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(475.7f, 354.9f, 179.2f);
        needRotaton = Quaternion.AngleAxis(45f, new Vector3(1, 0, 0));
    }
    public void Move1()         //функция для просмотра Выпрямителя
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(495.1f, 340.6f, 222.2f);
        needRotaton = Quaternion.AngleAxis(45f, new Vector3(1, 0, 0));
    }
    public void Move2()     //функция для просмотра делителя
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(499.6f, 339.8f, 196.2f);
        needRotaton = Quaternion.AngleAxis(45f, new Vector3(1, 0, 0));
    }
    public void Move3()     //функция для просмотра Амперметра
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(486.7f, 345f, 212.2f);
        needRotaton = Quaternion.AngleAxis(90f, new Vector3(1, 0, 0));
    }
    public void Move4()     //функция для просмотра вольтметра
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(474f, 345f, 214.1f);
        needRotaton = Quaternion.AngleAxis(90f, new Vector3(1, 0, 0));
    }
    public void Move5()     //функция для просмотра миллиамперметра
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(462.9f, 350f, 212.2f);
        needRotaton = Quaternion.AngleAxis(90f, new Vector3(1, 0, 0));
    }

    public void Move6()     //функция для просмотра резистра
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(476.2f, 340.4f, 215.6f);
        needRotaton = Quaternion.AngleAxis(45f, new Vector3(1, 0, 0));
    }

    public void Move7()     //функция для просмотра Лампы
    {
        move = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = new Vector3(459.6f, 338.8f, 219.8f);
        needRotaton = Quaternion.AngleAxis(45f, new Vector3(1, 0, 0));
    }

 

    void Update()
    {
        if (move)
        {
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            transform.rotation = Quaternion.Slerp(startRotation, needRotaton, offset);
            if (offset >= 1)
            {
                move = false;
                offset = 0;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageinfoopen : MonoBehaviour {
    [SerializeField]
    Text message;

    public void OnSettings()
    {
        message.text = "Данный симулятор служит для определения работы выхода электрона из металла";

    }
    public void OnExit()
    {
        message.text = "Не включать без одобрения преподавателя!!!";

    }

}

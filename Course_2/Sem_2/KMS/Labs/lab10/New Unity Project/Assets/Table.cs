using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
    public GameObject gameObject;
    void Start()
    {
        Close();
    }

    public void Open()
    {
        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}

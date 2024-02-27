using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color currentColor;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            currentColor = GetComponent<Renderer>().material.color;
        }
    }

    public void ChangeCol()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            GetComponent<Renderer>().material.color = new Color(0, 1, 1); 
        }
    }

    public void ReturnCol()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            GetComponent<Renderer>().material.color = currentColor; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour, IPointerClickHandler {
    public GameObject Cube;
    public void OnPointerClick(PointerEventData eventData)
    {
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);

        Color col1 = new Color(red, green, blue);
        Cube.GetComponent<Renderer>().material.color = col1;
        int forse = 500;
        Vector3 tar = eventData.pointerPressRaycast.worldPosition;
        Vector3 col = Camera.main.transform.position;
        Vector3 direction = tar - col;
        direction = direction.normalized;
        col = direction * forse;
        Cube.GetComponent<Rigidbody>().AddForceAtPosition(col, tar);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public GameObject prefab;
    public Vector3 prefabpos;

    // Use this for initialization
    void Start()
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        minX = renderer.bounds.min.x;
        maxX = renderer.bounds.max.x;
        minZ = renderer.bounds.min.z;
        maxZ = renderer.bounds.max.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            prefabpos = new Vector3(10 + Random.Range(minX, maxX), 20, 10 + Random.Range(minZ, maxZ));
            Instantiate(prefab, prefabpos, Quaternion.identity); // Добавлено: сохраняем ссылку на созданный экземпляр
        }
    }
}

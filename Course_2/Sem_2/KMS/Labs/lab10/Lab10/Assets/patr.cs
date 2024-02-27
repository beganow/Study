using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patr : MonoBehaviour {
    float speed_bullet = 0.3f;

    public GameObject explosion;
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public AudioSource zvvzriv;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 10f);
        Cube1 = GameObject.Find("Cube1");
        Cube2 = GameObject.Find("Cube2");
        Cube3 = GameObject.Find("Cube3");
        Cube4 = GameObject.Find("Cube4");
        zvvzriv = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.TransformDirection(Vector3.forward * speed_bullet);
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == Cube1)
        {
            Cube1.GetComponent<Renderer>().material.color = Color.red;
        }
        if (col.gameObject == Cube2)
        {
            Cube2.GetComponent<Renderer>().material.color = Color.red;
        }
        if (col.gameObject == Cube3)
        {
            Cube3.GetComponent<Renderer>().material.color = Color.red;
        }
        if (col.gameObject == Cube4)
        {
            Cube4.GetComponent<Renderer>().material.color = Color.red;
            Cube4.GetComponent<Renderer>().enabled = false;
            Instantiate(explosion, Cube4.transform.position, Quaternion.identity);
            zvvzriv.gameObject.GetComponent<AudioSource>().PlayOneShot(zvvzriv.gameObject.GetComponent<AudioSource>().clip);
        }
    }
}

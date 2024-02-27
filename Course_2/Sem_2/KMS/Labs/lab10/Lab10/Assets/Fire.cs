using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public GameObject core;
    public AudioSource zvpushka;
    public bool isPlaying = false;
    // Use this for initialization
    void Start()
    {
        zvpushka = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float spawnPoint = gameObject.GetComponent<Renderer>().bounds.size.z;
            Vector3 ForwardObj = transform.position + transform.TransformDirection(Vector3.forward * spawnPoint*2f);
            GameObject newBullet = Instantiate(core, ForwardObj, transform.rotation);
            newBullet.transform.Rotate(new Vector3(90, 0, 0));
            zvpushka.GetComponent<AudioSource>().PlayOneShot(zvpushka.GetComponent<AudioSource>().clip);
        }
    }
}

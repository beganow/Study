using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    float get_x;
    float get_z;

    float mouse_x;
    float mouse_y;

    float Barrel_rotation_x;

    GameObject tower;
    GameObject barrel;
    public AudioSource zvtank;
    public bool isPlaying = false;
    // Use this for initialization
    void Start () {
        tower = GameObject.Find("Башня");
        barrel = GameObject.Find("Пушка");
        zvtank = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        get_z = Input.GetAxis("Vertical");

        transform.Translate(get_z / 16, 0 , 0);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -0.5f, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0.5f, 0);
        }

        mouse_y = Input.GetAxis("Mouse X");

        tower.transform.Rotate(0, mouse_y, 0);

        mouse_x = Input.GetAxis("Mouse Y");

        Barrel_rotation_x += -mouse_x;

        Barrel_rotation_x = Mathf.Clamp(Barrel_rotation_x, -20f, 5f);

        barrel.transform.rotation = Quaternion.Euler(Barrel_rotation_x, barrel.transform.rotation.eulerAngles.y, barrel.transform.rotation.eulerAngles.z);
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !isPlaying)
        { zvtank.Play(); isPlaying = true; }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && isPlaying)
        { zvtank.Stop(); isPlaying = false; }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureEnter : MonoBehaviour {

    float get_x;
    float get_z;

    float mouse_x;
    float mouse_y;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject Capsule;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        get_x = Input.GetAxis("Horizontal");
        get_z = Input.GetAxis("Vertical");

        transform.Translate(get_x, 0, get_z);

        mouse_y = Input.GetAxis("Mouse X");
        mouse_x = Mathf.Clamp(Input.GetAxis("Mouse Y"), 0f, 90f);

        transform.Rotate(Vector3.up, mouse_y);
        transform.Rotate(Vector3.right, mouse_x);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cube1.GetComponent<Renderer>().material.mainTexture = Resources.Load("picture") as Texture;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            cube2.GetComponent<Renderer>().material.mainTexture = Resources.Load("picture") as Texture;
        }
    }


    public void OnCollisionEnter(Collision col)
    {
        UnityEngine.Texture newTexture = Capsule.gameObject.GetComponent<Renderer>().material.mainTexture;
        if (col.gameObject.CompareTag("Cubeone"))
        {
            cube1.GetComponent<Renderer>().material.mainTexture = newTexture;
        }
        if (col.gameObject.CompareTag("Cubetwo"))
        {
            cube2.GetComponent<Renderer>().material.mainTexture = newTexture;
        }
    }
}

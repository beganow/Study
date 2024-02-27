using UnityEngine;

public class Capsule_GetAXIS : MonoBehaviour
{
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
    }

   public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Cubeone"))
        {
            Color newColor = Capsule.gameObject.GetComponent<Renderer>().material.color;
            cube1.GetComponent<Renderer>().material.color = newColor;
        }
        if (col.gameObject.CompareTag("Cubetwo"))
        {
            Color newColor = Capsule.gameObject.GetComponent<Renderer>().material.color;
            cube2.GetComponent<Renderer>().material.color = newColor;
        }
    }
}

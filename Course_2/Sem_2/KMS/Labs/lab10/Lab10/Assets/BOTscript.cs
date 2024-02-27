using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTscript : MonoBehaviour {
    float movespeed = 0.1f;	// скорость передвижения танка-бота
    float rotspeedtank = 0.3f;	// скорость поворота танка-бота
    float rotspeedbash = 0.5f;	// скорость поворота башни танка-бота
    float speedcore = 3f;		// скорость снаряда танка-бота
    public Transform bash;	// для управления башней
    public Transform stvol;	// для управления стволом
    public GameObject core;	// для ссылки на префаб снаряда
    bool canshoot = true;	// для определения, может ли танк-бот произвести выстрел
    int life = 3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 relativePos = other.transform.position - transform.position;
            Quaternion newrot = Quaternion.LookRotation(relativePos) * Quaternion.AngleAxis(-90, Vector3.up);

            bash.rotation = Quaternion.Slerp(bash.rotation, newrot, Time.deltaTime * rotspeedbash);

            RaycastHit hit;
            if (Physics.Raycast(bash.position, bash.TransformDirection(Vector3.right), out hit))
            {
                if (hit.transform.tag == "Player" && canshoot)
                {
                    StartCoroutine(botshoot());
                }
            }

            float distance = Vector3.Distance(other.transform.position, transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, newrot, Time.deltaTime * rotspeedtank);
            if (distance < 50)
            {
                transform.position = Vector3.Lerp(transform.position, other.transform.position, Time.deltaTime * movespeed);
            }
        }
    }
    IEnumerator botshoot()
    {
        canshoot = false;
        Vector3 forwardofstvol = stvol.transform.position + stvol.TransformDirection(Vector3.forward * 2f);
        GameObject newcore = Instantiate(core, forwardofstvol, stvol.rotation);
        yield return new WaitForSeconds(3f);
        canshoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Core")
        {
            life--;
            if (life < 1)
                Destroy(gameObject);

        }
    }
}

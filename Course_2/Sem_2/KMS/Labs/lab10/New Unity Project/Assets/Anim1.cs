using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim1 : MonoBehaviour
{
    public Animator anim; 

    void Start()
    {
        anim = GetComponent<Animator>(); //������������� ����������� �������� 

    }

    void OnMouseDown()
    {
        anim.SetBool("variant", true);
    }
}

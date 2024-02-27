using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provod : MonoBehaviour {
    public Animator anim;
    public Animator anim1;

    void Start()
    {
        anim = GetComponent<Animator>(); //инициализация контроллера анимации 

    }

    void OnMouseEnter()
    {
         anim.SetTrigger("Provod");
         anim1.SetTrigger("back"); 
        anim1.SetTrigger("Nullen"); } // переменная, отвечающая за переход имеет значение true
    }


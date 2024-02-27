using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChangeV : MonoBehaviour {
	public Animator anim;
    public Animator anim2;
    public Animator anim3;
    public GameObject gameObject;

    private int state = 0;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
   
    }

    // Update is called once per frame
    void OnMouseDown() {
        Renderer rend = gameObject.GetComponent<Renderer>();
        switch (state)
            {
                case 0:
                anim.ResetTrigger("OnMove5");
                anim2.ResetTrigger("V6");
                anim3.ResetTrigger("Start5");
                anim.SetTrigger("OnMove");
                    anim2.SetTrigger("V");
                    anim3.SetTrigger("Start");
                rend.material.color = Color.Lerp(Color.white, Color.yellow, 0.3f);
                state++;
                    break;
                case 1:
                    anim.ResetTrigger("OnMove");
                    anim2.ResetTrigger("V");
                    anim3.ResetTrigger("Start");
              
                anim.SetTrigger("OnMove1");
                    anim2.SetTrigger("V2");
                    anim3.SetTrigger("Start1");
                rend.material.color = Color.Lerp(Color.white, Color.yellow, 0.5f); ;
                state++;
                    break;
                case 2:
                    anim.ResetTrigger("OnMove1");
                    anim2.ResetTrigger("V2");
                    anim3.ResetTrigger("Start1");
           
                anim.SetTrigger("OnMove2");
                    anim2.SetTrigger("V3");
                    anim3.SetTrigger("Start2");
                rend.material.color = Color.Lerp(Color.white, Color.yellow, 0.75f); ;
                state++;
                    break;
                case 3:
                    anim.ResetTrigger("OnMove2");
                    anim2.ResetTrigger("V3");
                    anim3.ResetTrigger("Start2");
             
                anim.SetTrigger("OnMove3");
                    anim2.SetTrigger("V4");
                    anim3.SetTrigger("Start3");
                rend.material.color = Color.Lerp(Color.white, Color.yellow, 0.85f); ;
                state++;
                    break;
                case 4:
                    anim.ResetTrigger("OnMove3");
                    anim2.ResetTrigger("V4");
                    anim3.ResetTrigger("Start3");
             
                anim.SetTrigger("OnMove4");
                    anim2.SetTrigger("V5");
                    anim3.SetTrigger("Start4");
                rend.material.color = Color.Lerp(Color.white, Color.yellow, 0.9f); ;
                state++;
                    break;
                case 5:
                    anim.ResetTrigger("OnMove4");
                    anim2.ResetTrigger("V5");
                anim3.ResetTrigger("Start4");
                anim.SetTrigger("OnMove5");
                    anim2.SetTrigger("V6");
                    anim3.SetTrigger("Start5");
                rend.material.color = Color.yellow;
                state = 1;
                break;
            }
        }
       
    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimRoz : MonoBehaviour
{
    public Animator anim;
    public float rotationAngle = 60f; // Скорость вращения объекта
    public GameObject gameObject1;
    private Vector3 startPositiongo1;
    private Vector3 startRotationgo1;
    private Vector3 currentPosition1;
    public GameObject gameObject2;
    public Animator anim2;
    public Animator anim3;
    private bool variantActivated = false;
    enum Mode { Max, Mid, Min }
    Mode currentMode = Mode.Mid;// Перечисление для трех режимов
    void Start()
    {
        anim = GetComponent<Animator>();
        startPositiongo1 = gameObject1.transform.position;
        startRotationgo1 = gameObject1.transform.eulerAngles;
        anim2.SetTrigger("Mid");
        anim3.SetTrigger("back");
    }

    void OnMouseDown()
    {
        anim.SetBool("variant", true);
        variantActivated = true;
    }
    void Update()
    {
        if (variantActivated)
        {
            if (Input.GetMouseButtonDown(1))
            {
                anim.SetBool("variant", false);
                variantActivated = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {

                float newRotation = Mathf.Clamp(gameObject1.transform.eulerAngles.z + 60f, 100f, 160f);
                    gameObject1.transform.eulerAngles = new Vector3(gameObject1.transform.eulerAngles.x, gameObject1.transform.eulerAngles.y, newRotation);
                 if (currentMode == Mode.Max)
                {
                    currentMode = Mode.Max;
                }
                else if (currentMode == Mode.Mid)
                {
                    currentMode = Mode.Max;
                    anim2.SetTrigger("Max");
                    anim3.SetTrigger("max");
                }
                else if (currentMode == Mode.Min)
                {
                    currentMode = Mode.Mid;
                    anim2.SetTrigger("Mid");
                    anim3.SetTrigger("back");
                }
             
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentMode == Mode.Mid)
                {
                    currentMode = Mode.Min;
                    anim2.SetTrigger("Min");
                    anim3.SetTrigger("start");

                }
                else if (currentMode == Mode.Max)
                {
                    currentMode = Mode.Mid;
                    anim2.SetTrigger("Mid");
                    anim3.SetTrigger("back");

                }
                else if (currentMode == Mode.Min)
                {
                    currentMode = Mode.Min;
                }
                    float newRotation = Mathf.Clamp(gameObject1.transform.eulerAngles.z - 60f, 40f, 100f);
                    gameObject1.transform.eulerAngles = new Vector3(gameObject1.transform.eulerAngles.x, gameObject1.transform.eulerAngles.y, newRotation);
                }
            }
        }
    }

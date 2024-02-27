using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableInsert : MonoBehaviour {
    public int Stepid = 1;
   [SerializeField]
    public InputField textInput;

    [SerializeField]
    public Text I1n;
    [SerializeField]
    public Text RT1;
    [SerializeField]
    public Text U1n;
    [SerializeField]
    public Text I2n;
    [SerializeField]
    public Text RT2;
    [SerializeField]
    public Text U2n;
    [SerializeField]
    public Text I3n;
    [SerializeField]
    public Text RT3;
    [SerializeField]
    public Text U3n;
    [SerializeField]
    public Text Ia1;
    [SerializeField]
    public Text Ia2;
    [SerializeField]
    public Text Ia3;
    [SerializeField]
    public Text Ia4;
    [SerializeField]
    public Text Ia5;
    [SerializeField]
    public Text Ia6;
    [SerializeField]
    public Text T1;
    [SerializeField]
    public Text T2;
    [SerializeField]
    public Text T3;
    [SerializeField]
    public Text A1;
    [SerializeField]
    public Text A2;
    [SerializeField]
    public Text A3;
    [SerializeField]
    public Text A;
    public void Add()
    {
        if (Stepid == 1 && !string.IsNullOrEmpty(textInput.text)) {
            I1n.text = textInput.text;
            Stepid++;
        }
        else if (Stepid == 2 && !string.IsNullOrEmpty(textInput.text))
        {
            U1n.text = textInput.text;
            double Res = Convert.ToDouble(U1n.text) / Convert.ToDouble(I1n.text);
            RT1.text = Convert.ToString(Res);
            Stepid++;
        }
        else if (Stepid == 3 && !string.IsNullOrEmpty(textInput.text))
        {
            I2n.text = textInput.text;
            Stepid++;
        }
        else if (Stepid == 4 && !string.IsNullOrEmpty(textInput.text))
        {
            U2n.text = textInput.text;
            double Res = Convert.ToDouble(U2n.text) / Convert.ToDouble(I2n.text);
            RT2.text = Convert.ToString(Res);
            Stepid++;
        }
        else if (Stepid == 5 && !string.IsNullOrEmpty(textInput.text))
        {
            I3n.text = textInput.text;
            Stepid++;
        }
        else if (Stepid == 6 && !string.IsNullOrEmpty(textInput.text))
        {
            U3n.text = textInput.text;
            double Res = Convert.ToDouble(U3n.text) / Convert.ToDouble(I2n.text);
            RT3.text = Convert.ToString(Res);
            Stepid++;
        }
        else if (Stepid == 7 && !string.IsNullOrEmpty(textInput.text))
        {
            Ia1.text =  textInput.text;
            Stepid++;
        }
        else if (Stepid == 8 && !string.IsNullOrEmpty(textInput.text))
        {
            Ia2.text =  textInput.text;
            Stepid++;
        }
        else if (Stepid == 9 && !string.IsNullOrEmpty(textInput.text))
        {
            Ia3.text =  textInput.text;
            Stepid++;
        }
        else if (Stepid == 10 && !string.IsNullOrEmpty(textInput.text))
        {
            Ia4.text =  textInput.text;
            Stepid++;
        }
        else if (Stepid == 11 && !string.IsNullOrEmpty(textInput.text))
        {
            Ia5.text =  textInput.text;
            Stepid++;
        }
        else if (Stepid == 12 && !string.IsNullOrEmpty(textInput.text))
        {
            Ia6.text =  textInput.text;
            Stepid++;
        }
        else if (Stepid == 13)
        {
            double res1 = 8.93 * (1 / Math.Pow(10, -5));
            double res2 = Convert.ToDouble(T1.text) * Convert.ToDouble(T2.text) / (Convert.ToDouble(T2.text) - Convert.ToDouble(T1.text));
            double res4 = Convert.ToDouble(I2n) / Convert.ToDouble(I1n);
            double res5 = Convert.ToDouble(T2.text) / Convert.ToDouble(T1.text);
            double res3 = Math.Log(res4) - 2 * Math.Log(res5);
            double A12 = (res1 * res2 * res3) / 100000000 + 6;
            double res12 = 8.93 * (1 / Math.Pow(10, -5));
            double res22 = Convert.ToDouble(T2.text) * Convert.ToDouble(T3.text) / (Convert.ToDouble(T2.text) - Convert.ToDouble(T1.text));
            double res42 = Convert.ToDouble(I3n) / Convert.ToDouble(I2n);
            double res52 = Convert.ToDouble(T3.text) / Convert.ToDouble(T2.text);
            double res32 = Math.Log(res42) - 2 * Math.Log(res52);
            double A22 = (res12 * res22 * res32) / 100000000 + 6;
            double res13 = 8.93 * (1 / Math.Pow(10, -5));
            double res23 = Convert.ToDouble(T3.text) * Convert.ToDouble(T1.text) / (Convert.ToDouble(T2.text) - Convert.ToDouble(T1.text));
            double res43 = Convert.ToDouble(I3n) / Convert.ToDouble(I1n);
            double res53 = Convert.ToDouble(T3.text) / Convert.ToDouble(T1.text);
            double res33 = Math.Log(res43) - 2 * Math.Log(res53);
            double A32 = (res13 * res23 * res33) / 100000000 + 6;
            double A99 = (A12 + A22 + A32)/3; 
            A1.text = "A1 = " + Convert.ToString(A12) + " эВ";
            A2.text = "A2 = " + Convert.ToString(A22) + " эВ";
            A3.text = "A3 = " + Convert.ToString(A32) + " эВ";
            A.text = "A =  " + Convert.ToString(A99) + " эВ";


        }
    }
        public void Clear()
        {
            textInput.text = "";
            I1n.text = "";
            RT1.text = "";
            U1n.text = "";
            I2n.text = "";
            RT2.text = "";
            U2n.text = "";
            I3n.text = "";
            RT3.text = "";
            U3n.text = "";

            Ia1.text = "";
            Ia2.text = "";
            Ia3.text = "";
            Ia4.text = "";
            Ia5.text = "";
            Ia6.text = "";
            A1.text = "";
            A2.text = "";
            A3.text = "";
            A.text = "";
            Stepid = 1;
        }
    }


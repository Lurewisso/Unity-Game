using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using UnityEngine.UIElements;


public class revolverScript : MonoBehaviour
{
    
     
    public Image revolver;
    public Image lightSaber;
    public Image crossbow;
    public Image medicine;
    //private float targetAlpha = 0.5f;
    


    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            var aboba = revolver.GetComponent<Image>();
            Color color = aboba.color;
            color.a = 1;
            color = Color.green;
            aboba.color = color;

            var knife = lightSaber.GetComponent<Image>();
            Color color2 = knife.color;
            color2.a = 1;
            color2 = Color.gray;
            knife.color = color2;

            var banana = crossbow.GetComponent<Image>();
            Color color3 = banana.color;
            color3 = Color.gray;
            color3.a = 1;
            banana.color = color3;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            var aboba = revolver.GetComponent<Image>();
            Color color1 = aboba.color;
            color1.a = 0.5f;
            color1 = Color.gray;
            aboba.color = color1;

            var knife = lightSaber.GetComponent<Image>();
            Color color2 = knife.color;
            color2 = Color.green;
            //color2.a = 0.5f;
            knife.color = color2;

            var banana = crossbow.GetComponent<Image>();
            Color color3 = banana.color;
            color3 = Color.gray;
            color3.a = 1;
            banana.color = color3;


        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            var aboba = revolver.GetComponent<Image>();
            Color color1 = aboba.color;
            color1.a = 1;
            color1 = Color.gray;
            aboba.color = color1;

            var knife = lightSaber.GetComponent<Image>();
            Color color2 = knife.color;
            color2 = Color.gray;
            color2.a = 1;
            knife.color = color2;

     
            var banana = crossbow.GetComponent<Image>();
            Color color3 = banana.color;
            color3 = Color.red;
            color3.a = 1;
            banana.color = color3;
        }
       }
    }

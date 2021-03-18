using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prueba : MonoBehaviour
{
    public GameObject texto_Suma;
    public GameObject[]  textos;

    void Start()
    {
        texto_Suma = GameObject.Find("Text");
        texto_Suma.GetComponent<Text>().text = "Hola";
        texto_Suma.GetComponent<Text>().color = Color.red;

        /// todos los textos
        textos = GameObject.FindGameObjectsWithTag("ejemplo");

        foreach(GameObject T in textos){
        	T.GetComponent<Text>().text = "Hola";
        	T.GetComponent<Text>().color = Color.red;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

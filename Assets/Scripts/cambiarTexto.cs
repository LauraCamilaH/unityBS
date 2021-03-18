using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cambiarTexto : MonoBehaviour
{
    private GameObject textoInicial;
    private Color colorTexto;

    private GameObject[] textos;
    void Start()
    {
        colorTexto = new Vector4(0.5f, 1f, 0.3f, 0.5f);
        textoInicial = GameObject.Find("Text");
        textoInicial.GetComponent<Text>().text = "Hola";
        textoInicial.GetComponent<Text>().color = colorTexto;//Color.red;
    	//////////////////////////

        textos = GameObject.FindGameObjectsWithTag("grupoTextos");

        foreach(GameObject t in textos){
        	t.GetComponent<Text>().text = "DE NUEVO";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


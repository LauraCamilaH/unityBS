using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ocultar : MonoBehaviour
{
    private GameObject imagenVida;
    private Text texto;
    public int contador;
    void Start()
    {
        contador = 5;

        
        texto = GameObject.Find("Text").GetComponent<Text>();
        texto.text = contador.ToString();
        //Destroy(imagenVida);

        //imagenVida.SetActive(false);

    }

    public void eliminar(){
    	contador--;
    	texto.text = contador.ToString();
    	imagenVida = GameObject.Find("Vidas");
    	imagenVida.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cambioTexto : MonoBehaviour
{
    public Text titulo;
    // creamos un array para guardar todos los botones con el mismo nombre
    public GameObject[] todosBotones;
    // Start is called before the first frame update
    void Start()
    {
        titulo = GameObject.Find("text_todos").GetComponent<Text>();
        titulo.text = "HOla"; // cambia el nombre

        //todosBotones = GameObject.FindGameObjectsWithTag("option");
    }

   
}

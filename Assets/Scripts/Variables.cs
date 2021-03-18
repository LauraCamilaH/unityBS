using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    static public int operacion = 0;
    static public string nombre_jugador = "";

    public void setOperacion(int op){
    	operacion = op;
    }

    public void setNombreJugador(string nombre){
    	nombre_jugador =  nombre;
    }
}

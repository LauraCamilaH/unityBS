using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;




public class operaciones : MonoBehaviour

{
    private int operacion,  vidas, puntos;
    private float respuesta;
    private string simbolo;
    

    private Text txt_operacion, op1, op2, op3, op4, txt_vidas, txt_puntos;
    private Text[] textos_botones = new Text[4];

    private ArrayList posiciones_iniciales = new ArrayList(4);
    private ArrayList orden_inicial = new ArrayList(4);
    private ArrayList valores_iniciales = new ArrayList(4);

    private GameObject gameover;
    private GameObject[] buttonObjs;
    private GameObject[] imagenes_vidas;




    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        vidas = 3;
        imagenes_vidas = GameObject.FindGameObjectsWithTag("vidas");

        gameover = GameObject.Find("ima_gameover");
        gameover.SetActive(false);

     

        // operacion = variables.operacion;
        operacion = Variables.operacion;

        txt_operacion = GameObject.Find("txt_operacion").GetComponent<Text>();
        txt_puntos = GameObject.Find("txt_puntos").GetComponent<Text>();
        txt_vidas = GameObject.Find("txt_vidas").GetComponent<Text>();



        op1 = GameObject.Find("resultado_1").GetComponent<Text>();
        op2 = GameObject.Find("resultado_2").GetComponent<Text>();
        op3 = GameObject.Find("resultado_3").GetComponent<Text>();
        op4 = GameObject.Find("resultado_4").GetComponent<Text>();


        buttonObjs = GameObject.FindGameObjectsWithTag("option");


        for (int i=0; i< buttonObjs.Length; i++)
        {
            posiciones_iniciales.Add(buttonObjs[i].transform.position);
        }

        orden_inicial.Clear();
        orden_inicial.Add(0);
        orden_inicial.Add(1);
        orden_inicial.Add(2);
        orden_inicial.Add(3);

        textos_botones[0] = op1;
        textos_botones[1] = op2;
        textos_botones[2] = op3;
        textos_botones[3] = op4;

        operar();

    }

    private void operar()
    {

        setSimbolo();

        float n1 = UnityEngine.Random.Range(1, 11);
        float n2 = UnityEngine.Random.Range(1, 11);


        txt_operacion.text = n1.ToString() + "  " + simbolo + "   " + n2.ToString();
        
        


        valores_iniciales.Clear();
        valores_iniciales.Add((n1 + n2).ToString());
        valores_iniciales.Add((n1 - n2).ToString());
        valores_iniciales.Add((n1 * n2).ToString());
        if (n1 % n2 == 0)
        {
            valores_iniciales.Add((n1 / n2).ToString());
        }
        else
        {
            valores_iniciales.Add((n1 / n2).ToString("0.0"));

        }

        set_textoBotones();

        random_color_boton();

        respuesta = getRespuesta(n1, n2);
    }
    private void set_textoBotones()
        {
            ArrayList posiciones_nuevas = Aleotorizar_arrayList (orden_inicial);

            for(int i = 0; i<textos_botones.Length; i++)
            {
                int indice = (int)posiciones_nuevas[i];
                textos_botones[i].text = (string) valores_iniciales[indice];
            }
        }

   ArrayList Aleotorizar_arrayList (ArrayList original)
    {
        ArrayList nuevo_array = new ArrayList(4);
        int contador = 0;
        while(contador < original.Count)
        {
            int indice = UnityEngine.Random.Range(0, original.Count);
            if (nuevo_array.Contains(original[indice]) == false)
            {
                nuevo_array.Add(original[indice]);
                contador++;
            }
        }
        return nuevo_array;
    }


    private void random_color_boton()
    {
        for (int i=0; i < buttonObjs.Length; i++)
        {
            Color rc = new Color(UnityEngine.Random.Range(0.01f, 1f),
                UnityEngine.Random.Range(0.01f, 1f),
                UnityEngine.Random.Range(0.01f, 1f));
            buttonObjs[i].GetComponent<Image>().color = rc;
        }
    }

    private Color Color_invertido(Color original)
    {
        float H, S, V;

        Color.RGBToHSV(original, out H, out S, out V);
        H = (H + 1f) % 1.0f;
        //S = (H + 1f) % 1.0f;
        //V = (H + 1f) % 1.0f;
        return Color.HSVToRGB(H,S,V);
    }
    private float getRespuesta (float n1, float n2)
    {
        float res = 0f;

        if (simbolo == "+")
        {
            res = (n1 + n2);
        }  else if (simbolo == "-")
        {
            res = (n1 - n2);
        } else if (simbolo == "x")
        {
            res =( n1 * n2);
        } else
        {
            res = (float)System.Math.Round(n1 / n2, 1);
        }

        return res;
    }

    private void setSimbolo()
    {
        int op = operacion;
        if (operacion == 4)
        {
            op = UnityEngine.Random.Range(0, 4);
        }

        switch (op)
        {
            case 3:
                simbolo = "÷";
                break;
            case 2:
                simbolo = "x";
                break;
            case 1:
                simbolo = "-";
                break;
            case 0:
                simbolo = "+";
                break;

        }
    }

    public void calcularrespuesta(int valor)
    {

        switch (valor)
        {
            case 4:
                if((float) System.Math.Round(float.Parse(op4.text), 1) == (float)System.Math.Round(respuesta, 1)){
                    operar();
                    Debug.Log("correcto 4");
                    agregar_puntos();
                }
                else
                {
                    Debug.Log("INCORRECTO 4");
                    eliminar_vidas();

                }
                break;
            case 3:
                if (float.Parse(op3.text) == respuesta)
                {
                    operar();
                    Debug.Log("correcto 3");
                    agregar_puntos();
                }
                else
                {
                    Debug.Log("INCORRECTO 3");
                    eliminar_vidas();
                }
                break;
            case 2:
                if (float.Parse(op2.text) == respuesta)
                {
                    operar();
                    Debug.Log("correcto 2");
                    agregar_puntos();
                }
                else
                {
                    Debug.Log("INCORRECTO 2");
                    eliminar_vidas();
                }
                break;
            case 1:
                if (float.Parse(op1.text) == respuesta)
                {
                    operar();
                    Debug.Log("correcto 1 ");
                    agregar_puntos();

                }
                else
                {
                    Debug.Log("INCORRECTO 1");
                    eliminar_vidas();
                }
                break;


        }
    }

    public void eliminar_vidas()
    {

        //GameObject[]imagenes_vidas = GameObject.FindGameObjectsWithTag("vidas");

        if (vidas > 1)
        {
            vidas--;
            txt_vidas.text = vidas.ToString();
        }else if (vidas <= 1)
        {
            vidas--;
            Debug.Log("finalizo el juego");
            gameover.SetActive(true);
        }
        imagenes_vidas[vidas].SetActive(false);

    }

    public  void agregar_puntos()
    {
        //GameObject[] imagenes_vidas = GameObject.FindGameObjectsWithTag("vidas");
        //primero respuesta no lo toma
        puntos++;
        txt_puntos.text = "puntos: " + puntos.ToString();


        if (vidas >0 && vidas < 3 && (puntos % 3 == 0))
        {
            agregar_vidas();

        }

    }

    public void agregar_vidas()
    {
       vidas++;
       imagenes_vidas[vidas].SetActive(true);
        txt_vidas.text = vidas.ToString();
    }

}

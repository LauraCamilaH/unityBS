using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class operaciones1 : MonoBehaviour {

	private int operacion;
	private float respuesta;
	private string simbolo;

	private Text txt_operacion, op1,op2,op3,op4;
    private Text[] textos_botones = new Text[4];

    private ArrayList posiciones_iniciales = new ArrayList(4);
    private ArrayList orden_inicial = new ArrayList(4);
    private ArrayList valores_iniciales = new ArrayList(4);

    private GameObject[] buttonObjs;

    
    private GameObject lapiz;
    private GameObject ImagenFinal;
    private int contador;
    private GameObject[]  lapices;

	void Start () {
        contador = 0;
        lapices = GameObject.FindGameObjectsWithTag("tag_vidas");     

        //lapiz = GameObject.Find("vidas");
        //lapiz.SetActive(false);

        ImagenFinal = GameObject.Find("ImagenFinal");
        ImagenFinal.SetActive(false);

        //Destroy(lapiz);

		operacion = Variables.operacion;
		txt_operacion = GameObject.Find("txt_operacion").GetComponent<Text>();
		op1 = GameObject.Find("resultado_1").GetComponent<Text>();
		op2 = GameObject.Find("resultado_2").GetComponent<Text>();
		op3 = GameObject.Find("resultado_3").GetComponent<Text>();
		op4 = GameObject.Find("resultado_4").GetComponent<Text>();

		buttonObjs = GameObject.FindGameObjectsWithTag("opcion");

        for(int i=0; i< buttonObjs.Length; i++){ 
        	posiciones_iniciales.Add(buttonObjs[i].transform.position);
        }
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

	private void operar(){

		setSimbolo();
        
		float n1 = UnityEngine.Random.Range(1,11);
		float n2 = UnityEngine.Random.Range(1,11);

    	txt_operacion.text =  n1.ToString() + " " + simbolo +  "  " + n2.ToString();

    	valores_iniciales.Clear();
    	valores_iniciales.Add((n1+n2).ToString());
    	valores_iniciales.Add((n1-n2).ToString());
    	valores_iniciales.Add((n1*n2).ToString());
    	if(n1%n2 ==0){
    		valores_iniciales.Add((n1/n2).ToString());  
    	}
    	else{
    		valores_iniciales.Add((n1/n2).ToString("0.0"));
    	}

    	set_textoBotones();
    	random_color_boton();
   	
    	respuesta = getRespuesta(n1,n2);

	}


    private void set_textoBotones(){

    	ArrayList posiciones_nuevas= Aleotorizar_arrayList(orden_inicial);

    	for(int i=0; i<textos_botones.Length; i++){

    		int indice = (int) posiciones_nuevas[i];
    		textos_botones[i].text = (string) valores_iniciales[indice];

    	}

    }

    ArrayList Aleotorizar_arrayList(ArrayList original){

        ArrayList nuevo_array = new ArrayList(4);
        int contador = 0;
        while(contador < original.Count){
            int indice = UnityEngine.Random.Range(0,original.Count);
            if(nuevo_array.Contains(original[indice])==false){
                nuevo_array.Add(original[indice]);
                contador++;
            }
        }

        return nuevo_array;

    }


    private void random_color_boton(){
    	for(int i=0; i< buttonObjs.Length; i++){ 
     		Color rc = new Color(UnityEngine.Random.Range(0.01f, 1f), UnityEngine.Random.Range(0.01f, 1f), UnityEngine.Random.Range(0.01f, 1f));
     		buttonObjs[i].GetComponent<Image>().color = rc;
    	} 
    }


    private Color Color_Invertido(Color original)
	{
		float H, S, V;

        Color.RGBToHSV(original, out H, out S, out V);
       // Debug.Log("H: " + H + " S: " + S + " V: " + V);
        H = (H + 1f) % 1.0f;
       // S = (S + 1f) % 1.0f;
        //V = (V + 1f) % 1.0f;

        return  Color.HSVToRGB(H,S,V);

	}	

	private float getRespuesta(float n1, float n2){
		float res = 0f;
		if (simbolo =="+"){
			res = n1 + n2;
		}
		else if (simbolo =="-"){
			res = n1 - n2;		
		}
		else if (simbolo =="x"){
			res = n1 * n2;
		}
		else{
			res = (float) System.Math.Round(n1 / n2, 1);
		}

		return res;
	}

	private void setSimbolo(){
		int op = operacion;
		if(operacion == 4){
			op = UnityEngine.Random.Range(0,4);
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

	public void calcularrespuesta(int valor){

        if(contador <3){
            lapices[contador].SetActive(false);
            contador++;
        }
        else{
            ImagenFinal.SetActive(true);

        }


		switch (valor)
        {
        case 4:
        	if((float) System.Math.Round(float.Parse(op4.text),1) == (float) System.Math.Round(respuesta,1)){
        		operar();
        		Debug.Log("correcto");
        	}
        	else{
        		Debug.Log("INCORRECTO division  " + (float) System.Math.Round(float.Parse(op4.text),1) + " " + respuesta  );
        	}
            break;
        case 3:
  			if(float.Parse(op3.text) == respuesta){
        		operar();
        		Debug.Log("correcto");
        	}
        	else{
        		Debug.Log("INCORRECTO");
        	}
            break;
        case 2:
        	if(float.Parse(op2.text) == respuesta){
        		operar();
        		Debug.Log("correcto");
        	}
        	else{
        		Debug.Log("INCORRECTO");
        	}
            break;
        case 1:
        	if(float.Parse(op1.text) == respuesta){
        		operar();
        		Debug.Log("correcto");
        	}
        	else{
        		Debug.Log("INCORRECTO");
        	}
            break;

        }
		
	}
}

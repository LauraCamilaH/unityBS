﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
   public void jugar(string nombre_escena){
   		SceneManager.LoadScene(nombre_escena, LoadSceneMode.Single);
   }
}

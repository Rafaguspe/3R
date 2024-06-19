using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Preguntas : ScriptableObject
{
    public string titlePregunta;
    public List<Respuestas> respuestas;
}

[Serializable]
public class Respuestas 
{  
    public string respuesta;
    public bool correcta;
}

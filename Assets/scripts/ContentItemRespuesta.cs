using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentItemRespuesta : MonoBehaviour
{
    public Toggle toggle;
    public TextMeshProUGUI RespuestaText;
    public Respuestas respuestas; 

    public bool GetStatus()
    {
        return toggle.isOn;
    }

    public void SetRespuestaText(string Data)
    {
        RespuestaText.text = Data;
    }

    public string GetRespuestaText()
    {
        return RespuestaText.text;
    }

    public void SetRespuestaData( Respuestas data)
    {
        respuestas = data;
    }

    public Respuestas GetRespuestas()
    {
        return respuestas;
    }
}

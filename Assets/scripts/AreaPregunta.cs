using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaPregunta : MonoBehaviour
{
    public static AreaPregunta Instance;
    public GameObject BG;
    public List<Preguntas> listPreguntas;
    public Respuestas repuestaCorrecta;
    public TextMeshProUGUI preguntaText;
    public Transform container;
    public Transform containerPrefab;
    public List<ContentItemRespuesta> contentItemList;
    public Button responderButton;
    int index;

    private void Awake()
    {
        Instance = this;
        responderButton.onClick.AddListener(() => CheckCorrect());
        BG.SetActive(false);
    }

    public void Show()
    {
        BG.SetActive(true);
        Load();
    }


    public void Clear()
    {
        contentItemList.Clear();
        foreach (Transform child in container)
        {
            if (child == containerPrefab)
            {
                continue;
            }
            Destroy(child.gameObject);
        }
    }

    public void Load()
    {
        Clear();
       preguntaText.text = listPreguntas[index].titlePregunta;
       foreach (var item in listPreguntas[index].respuestas)
       {
            if (item.correcta)
            {
                repuestaCorrecta = item;
            }

            GameObject prefab = Instantiate(containerPrefab.gameObject, container);
            ContentItemRespuesta contentItemRespuesta = prefab.GetComponent<ContentItemRespuesta>();
            contentItemRespuesta.SetRespuestaData(item);
            contentItemRespuesta.SetRespuestaText(item.respuesta);
            contentItemList.Add(contentItemRespuesta);
            prefab.SetActive(true);
       }

    }


    public void CheckCorrect()
    {
        BG.SetActive(false);

        foreach (var item in contentItemList)
        {
            if (item.GetStatus())
            {
                if (item.GetRespuestas() == repuestaCorrecta)
                {
                    StartCoroutine(Correct());
                }
                else
                {
                    StartCoroutine(Incorrect());
                }
            }
        }

    }

    private IEnumerator Incorrect()
    {
        Guarda.Instance.SetMessage("No es correcto!");
        yield return new WaitForSeconds(2.5f);
        Show();

    }

    private IEnumerator Correct()
    {
        Guarda.Instance.SetMessage("Genial!");
        index++;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Guarda.Instance.Move());
    }

}

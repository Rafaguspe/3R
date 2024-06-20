using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guarda : MonoBehaviour
{
    public static Guarda Instance;
    public List<string> mensajesList = new List<string>();
    public GameObject mensajeObj;
    public TextMeshProUGUI mensajeText;
    public List<Transform> posiciones ;
    int index = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1);
        Iniciar();
    }


    public void Iniciar()
    {
        transform.DOJump(posiciones[index].position, 10f, 1, 1f).OnComplete(() =>
        {
            transform.DOMove(posiciones[index].position, 3f).OnComplete(() =>
            {
                index++;
                StartCoroutine(Mensajes());
                
            });
        });
    }

    public IEnumerator Mensajes()
    {
        foreach (string t in mensajesList)
        {
            mensajeText.text = t;

            yield return new WaitForSeconds(2);
        }
        StartCoroutine(Move());
    }


    public IEnumerator Move()
    {
        yield return new WaitForSeconds(1.2f);
        mensajeObj.SetActive(false);
        if (index < posiciones.Count)
        {
            transform.DOJump(posiciones[index].position, 10f,1,1f).OnComplete(() =>
            {
                index++;
                AreaPregunta.Instance.Show();
            });
        }
        else
        {
            Debug.Log("WIN");
            WIN();
        }

        
    }

    public void SetMessage(string Mensaje)
    {
        mensajeObj.SetActive(true);
        mensajeText.text = Mensaje;
        StartCoroutine(ShowMessage());
    }

    private IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(1f);
        mensajeObj.SetActive(false);

    }

    private void WIN()
    {
        string scene = SceneManager.GetActiveScene().name;
        //switch (scene)
        //{
        //    case "Ambiente urbano":
        //        AnimatorControllerUrbano.Instance.Stop();
        //        break;

        //    case "Ambiente costero":
        //        AnimatorControllerCostero.Instance.Stop();
        //        break;

        //    case "Ambiente marino":
        //        AnimatorControllerMarino.Instance.Stop();
        //        break;

        //    case "Ambiente fluvial":
        //        AnimatorControllerFluvial.Instance.Stop();
        //        break;

        //    case "Ambiente desértico":
        //        AnimatorControllerDesertico.Instance.Stop();
        //        break;

        //    case "Ambiente de incendios forestales":
        //        AnimatorControllerIncendiosForestales.Instance.Stop();
        //        break;

        //    case "Ambiente polar":
        //        AnimatorControllerPolar.Instance.Stop();
        //        break;

        //    case "Ambiente agrícola":
        //        AnimatorControllerAgricola.Instance.Stop();
        //        break;

        //    case "Cumbre de la ONU":
        //        StartCoroutine(AnimatorControllerCumbreONU.Instance.Stop());
        //        break;

        //}

        StartCoroutine(AnimatorControllerCumbreONU.Instance.Stop());
    }


}

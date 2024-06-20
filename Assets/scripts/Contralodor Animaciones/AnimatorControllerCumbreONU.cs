using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorControllerCumbreONU : MonoBehaviour
{
    public static AnimatorControllerCumbreONU Instance;
    public List<string> mensajesFinales;
    public GameObject BGInicial;
    public GameObject BGFinal;
    public string mensajeFinal;
    public string scene;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator Stop()
    {
        BGInicial.SetActive(false);
        BGFinal.SetActive(true);
        Guarda.Instance.mensajeObj.SetActive(true);
        foreach (var item in mensajesFinales)
        {
            Guarda.Instance.mensajeText.text = item;
            yield return new WaitForSeconds(2f);
        }

        StartCoroutine(Next());
    }


    private IEnumerator Next()
    {
        Guarda.Instance.SetMessage(mensajeFinal);
        yield return new WaitForSeconds(4);
        LoadSceneByName(scene);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

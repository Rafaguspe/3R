using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorControllerDesertico : MonoBehaviour
{
    public static AnimatorControllerDesertico Instance;
    public List<Animator> listAnimator;

    private void Awake()
    {
        Instance = this;
    }

    public void Stop()
    {
        foreach (Animator anim in listAnimator)
        {
            anim.speed = 0;
        }

        StartCoroutine(Next());
    }


    private IEnumerator Next()
    {
        Guarda.Instance.SetMessage("Vamos al bosque!");
        yield return new WaitForSeconds(4);
        LoadSceneByName("Ambiente de incendios forestales");
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorControllerPolar : MonoBehaviour
{
    public static AnimatorControllerPolar  Instance;
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
        Guarda.Instance.SetMessage("Vamos a la granja!");
        yield return new WaitForSeconds(4);
        LoadSceneByName("Ambiente agrícola");
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

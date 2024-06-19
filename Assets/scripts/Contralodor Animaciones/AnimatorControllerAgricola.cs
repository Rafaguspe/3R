using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorControllerAgricola : MonoBehaviour
{
    public static AnimatorControllerAgricola Instance;
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
        Guarda.Instance.SetMessage("Vamos a la ONU!");
        yield return new WaitForSeconds(4);
        LoadSceneByName("Cumbre de la ONU");
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

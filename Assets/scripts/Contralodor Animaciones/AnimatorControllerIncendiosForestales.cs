using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorControllerIncendiosForestales : MonoBehaviour
{
    public static AnimatorControllerIncendiosForestales Instance;
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
        Guarda.Instance.SetMessage("Vamos al polo!");
        yield return new WaitForSeconds(4);
        LoadSceneByName("Ambiente polar");
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

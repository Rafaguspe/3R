using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ENDManager : MonoBehaviour
{
    public Button HomeButton;
    public string Home;
    void Start()
    {
        HomeButton.onClick.AddListener(() => { LoadSceneByName(Home); });
    }


    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}

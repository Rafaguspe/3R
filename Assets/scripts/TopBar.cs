using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopBar : MonoBehaviour
{
    public Button Home;
    public Button Aventures;
    public Button Map;
    public Button Exit;
     
    void Start()
    {
        Home.onClick.AddListener(() => LoadSceneByName("Home"));
        Exit.onClick.AddListener(() => Application.Quit()) ;
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

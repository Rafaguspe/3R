using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;
    public string startScene;
    void Start()
    {
        StartButton.onClick.AddListener(() => LoadSceneByName(startScene));
        ExitButton.onClick.AddListener(() => Application.Quit());
    }


    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
